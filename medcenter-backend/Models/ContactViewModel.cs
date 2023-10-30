using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace medcenter_backend.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }


        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name2 { get; set; }


        [Display(Name = "Telefone com DDD")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MinLength(11, ErrorMessage = "Deve ter no mínimo 11 caracteres.")]
        public string Phone { get; set; }


        [Display(Name = "Endereço de E-mail")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]

        public string Email { get; set; }
    }
}
