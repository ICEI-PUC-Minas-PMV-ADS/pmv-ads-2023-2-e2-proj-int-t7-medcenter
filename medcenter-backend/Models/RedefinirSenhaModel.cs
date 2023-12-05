using System.ComponentModel.DataAnnotations;

namespace medcenter_backend.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmarSenha { get; set; }

        public string Token { get; set; }
    }
}
