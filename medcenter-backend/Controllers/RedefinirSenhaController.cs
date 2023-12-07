using System;
using System.Linq;
using System.Threading.Tasks;
using medcenter_backend.Models;
using medcenter_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medcenter_backend.Controllers
{
    [AllowAnonymous]
    public class RedefinirSenhaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailSender _emailSender;

        public RedefinirSenhaController(AppDbContext context, EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return RedirectToAction("EsqueciMinhaSenha");
        }

        public IActionResult EsqueciMinhaSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarLinkRedefinicao(RedefinirSenhaModel model)
        {
            // Verificar se o e-mail existe no banco de dados
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (usuario != null)
            {
                // Gera e salva o token e data de expiração
                usuario.TokenRedefinicaoSenha = Guid.NewGuid().ToString();
                usuario.ExpiracaoTokenRedefinicaoSenha = DateTime.UtcNow.AddHours(1);

                await _context.SaveChangesAsync();

                // Envia e-mail com o link de redefinição
                string subject = "Redefinição de Senha - Medcenter";
                string url = Url.Action("RedefinirSenha", "RedefinirSenha", new { token = usuario.TokenRedefinicaoSenha }, Request.Scheme);
                string message = $"Clique no link a seguir para redefinir sua senha: {url}";

                await _emailSender.SendEmail(subject, usuario.Email, usuario.Nome, message);

                // Defina a mensagem de sucesso
                ViewBag.SuccessMessage = "E-mail de redefinição enviado com sucesso. Verifique sua caixa de entrada.";

                // Redirecione para a view "EsqueciMinhaSenha"
                return View("EsqueciMinhaSenha");
            }

            // Se o e-mail não existe, não revelar isso ao usuário.
            ViewBag.Message = "Se o e-mail fornecido estiver correto, você receberá um e-mail de redefinição de senha.";
            return View("EsqueciMinhaSenha");
        }

        public IActionResult RedefinirSenha(string token)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.TokenRedefinicaoSenha == token &&
                u.ExpiracaoTokenRedefinicaoSenha.HasValue &&
                u.ExpiracaoTokenRedefinicaoSenha > DateTime.UtcNow);

            if (usuario != null)
            {
                var model = new RedefinirSenhaModel { Email = usuario.Email, Token = token };
                return View(model);
            }
            else
            {
                ViewBag.Message = "Link inválido ou expirado. Tente novamente.";
                return View("EsqueciMinhaSenha");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarSenha(RedefinirSenhaModel model)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.TokenRedefinicaoSenha == model.Token &&
                u.ExpiracaoTokenRedefinicaoSenha.HasValue &&
                u.ExpiracaoTokenRedefinicaoSenha > DateTime.UtcNow);

            if (usuario != null)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(model.NovaSenha);
                usuario.TokenRedefinicaoSenha = null;
                usuario.ExpiracaoTokenRedefinicaoSenha = null;

                await _context.SaveChangesAsync();

                ViewBag.Message = "Senha atualizada com sucesso! Faça o login com a nova senha.";
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                ViewBag.Message = "Link inválido ou expirado. Tente novamente.";
                return View("EsqueciMinhaSenha");
            }
        }
    }
}
