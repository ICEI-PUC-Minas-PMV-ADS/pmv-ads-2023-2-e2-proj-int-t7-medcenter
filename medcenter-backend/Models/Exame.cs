using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models {
    [Table("Exames")]
    public class Exame {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de realização do exame.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage ="Informe o tipo de exame realizado.")]
        [Display(Name ="Tipo de Exame")]
        public TipoExame TipoExame { get; set; }

        [Required(ErrorMessage ="Informe o profissional.")]
        public Profissional Profissional { get; set; }
    }

    public enum TipoExame {
        Hemograma, 
        Ultrassom,
        Tomografia,
        Radiografia,
        Densidometria
    }

    public enum Profissional {
        Dr_Ana_Paula,
        Dr_Pablo_Fuentes,
        Dr_Victor_Oliveira
    }
}
