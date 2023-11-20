using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medcenter_backend.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace medcenter_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var dados = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == usuario.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuario e/ou senha inválidos!";
                return View();
            }

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);
            if (senhaCorreta)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.NameIdentifier, dados.Email.ToString()),
                    new Claim(ClaimTypes.Role, dados.Perfil.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuario e/ou senha inválidos!";
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [AllowAnonymous]
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,Senha,Perfil")] Usuario usuario)
        {
            // Verifique se o e-mail já está em uso
            if (await EmailExists(usuario.Email))
            {
                ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                return View(usuario);
            }

            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                // Crie automaticamente um paciente associado ao usuário
                var novoPaciente = new Paciente
                {
                    Nome = usuario.Nome,
                    Telefone = usuario.Telefone,
                    Cpf = usuario.Cpf,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    UsuarioId = usuario.Id
                };

                _context.Add(novoPaciente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // Método para verificar se o e-mail já existe
        private async Task<bool> EmailExists(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        // GET: Usuarios/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Cpf,DataNascimento,Email,Senha,Perfil")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();

                    // Chame o método para criar ou remover a entidade associada ao perfil
                    if (usuario.Perfil == TipoPerfil.Medico)
                    {
                        await CriarMedicoAsync(usuario);
                    }
                    
                    else if (usuario.Perfil == TipoPerfil.Clinica)
                    {
                        await CriarClinicaAsync(usuario);
                    }
                    
                    else
                    {
                        // Se o tipo de perfil não for "Medico" nem "Clinica", remova a entidade associada, se existir
                        await RemoverEntidadeAsync(usuario.Id);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }


        // GET: Usuarios/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Usuário não encontrado para exclusão.");
            }

            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Removendo todos os dependentes associados ao paciente
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.UsuarioId == usuario.Id);
            if (paciente != null)
            {
                var dependentes = await _context.Dependentes.Where(d => d.PacienteId == paciente.Id).ToListAsync();
                _context.Dependentes.RemoveRange(dependentes);
                _context.Pacientes.Remove(paciente);
            }

            _context.Usuarios.Remove(usuario);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                // Lidar com a exceção de concorrência aqui, se necessário.
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task CriarMedicoAsync(Usuario usuario)
        {
            var medicoExistente = await _context.Medicos.FirstOrDefaultAsync(m => m.UsuarioId == usuario.Id);

            if (medicoExistente == null)
            {
                var novoMedico = new Medico
                {
                    Nome = usuario.Nome,
                    Telefone = usuario.Telefone,
                    Cpf = usuario.Cpf,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    UsuarioId = usuario.Id,
                    HoraInicioTrabalho = TimeSpan.FromHours(8),
                    HoraFimTrabalho = TimeSpan.FromHours(17),
                    Especialidade = Especialidade.ClinicoGeral
                };

                _context.Add(novoMedico);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CriarClinicaAsync(Usuario usuario)
        {
            var clinicaExistente = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuario.Id);

            if (clinicaExistente == null)
            {
                var novaClinica = new Clinica
                {
                    Nome = usuario.Nome,
                    Telefone = usuario.Telefone,
                    Email = usuario.Email,
                    Endereço = "A Definir",
                    HoraInicioFuncionamento = TimeSpan.FromHours(7),
                    HoraFimFuncionamento = TimeSpan.FromHours(18),
                    UsuarioId = usuario.Id,
                    // Adicione aqui os campos específicos da Clinica, se houver
                };

                _context.Add(novaClinica);
                await _context.SaveChangesAsync();
            }
        }

        

        private async Task RemoverEntidadeAsync(int usuarioId)
        {
            // Verifique se o usuário é um médico e remova, se existir
            await RemoverMedicoAsync(usuarioId);

            
            await RemoverClinicaAsync(usuarioId);
            
        }

        private Task RemoverMedicoAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        
         private async Task RemoverClinicaAsync(int usuarioId)
         {
             var clinicaExistente = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

             if (clinicaExistente != null)
             {
                 _context.Clinicas.Remove(clinicaExistente);
                 await _context.SaveChangesAsync();
             }
         }
        

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
