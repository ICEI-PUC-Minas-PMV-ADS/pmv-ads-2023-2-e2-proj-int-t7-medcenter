using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Medicos")]
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Campos de horário de trabalho
        public TimeSpan HoraInicioTrabalho { get; set; }
        public TimeSpan HoraFimTrabalho { get; set; }

        // Especialidade do médico
        public Especialidade Especialidade { get; set; }
    }

    public enum Especialidade
    {
        ClinicoGeral,
        Cardiologia,
        Dermatologia,
        Ortopedia,
        Pediatria,
        Outra
    }
}