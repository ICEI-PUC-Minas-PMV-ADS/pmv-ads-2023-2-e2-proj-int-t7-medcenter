using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Dependente> Dependentes { get; set; }
    }
}
