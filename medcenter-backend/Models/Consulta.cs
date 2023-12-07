using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        [Display(Name = "Dependente")]
        public int? DependenteId { get; set; }
        [ForeignKey("DependenteId")]
        public Dependente Dependente { get; set; }

        [Display(Name = "Clínica")]
        public int ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }

        [Display(Name = "Médico")]
        public int MedicoId { get; set; }
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        public DateTime DataConsulta { get; set; }

        public StatusConsulta Status { get; set; }

        public TipoConsulta TipoConsulta { get; set; }
    }
    public enum StatusConsulta
    {
        Agendada,
        Realizada,
        Cancelada
    }
    public enum TipoConsulta
    {
        Presencial,
        Online
    }
}
