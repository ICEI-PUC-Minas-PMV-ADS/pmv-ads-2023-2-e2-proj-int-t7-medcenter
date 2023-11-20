using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Clinicas")]
    public class Clinica
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Endereço { get; set; }

        public TimeSpan HoraInicioFuncionamento { get; set; }

        public TimeSpan HoraFimFuncionamento { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
