using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    [Table("Exames")]
    public class Exame
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

        [Display(Name = "Data do Exame")]
        public DateTime DataExame { get; set; }

        public StatusExame Status { get; set; }

        public TipoExame TipoExame { get; set; }

        [Display(Name = "Endereço")]
        public EnderecoExame Endereco { get; set; }
    }

    public enum StatusExame
    {
        Agendado,
        Realizado,
        Cancelado
    }

    public enum TipoExame
    {
        AcidoUrico,
        Albumina,
        Biopsia,
        Calcio,
        Chumbo,
        Cloretos,
        Colesterol,
        Covid19,
        Creatinina,
        Radiografia,
        RessonanciaMagnetica,
        Tomografia,
        Ultrassonografia
    }

    public enum EnderecoExame
    {
        [Display(Name = "Matriz - Santa Efigênia / Belo Horizonte-MG")]
        Matriz,

        [Display(Name = "Filial - Vila da Serra / Nova Lima-MG")]
        Filial
    }
}
