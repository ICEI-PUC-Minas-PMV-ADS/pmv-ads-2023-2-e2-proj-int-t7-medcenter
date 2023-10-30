using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace medcenter_backend.Models {
    [Table("Exames")]
    public class Exame {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de realizacao do exame.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Selecione o tipo do exame.")]
        [Display(Name = "Tipo de Exame")]
        public TipoExame TipoExame { get; set; }

        [Required(ErrorMessage = "Selecione o profissional.")]
        public Profissional Profissional { get; set; }
    }

    public enum TipoExame {
        Hemograma,
        Tomografia,
        Ultrassom,
        Radiografia
    }

    public enum Profissional {
        Dr_Ana_Clara,
        Dr_Pablo_Fuentes,
        Dr_Victor_Oliveira
    }
}