using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome.")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o CPF.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data de nascimento.")]
        [Display(Name="Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public TipoPerfil Perfil { get; set; }
    }
    public enum TipoPerfil
    {
        Paciente,
        Admin
    }
}
