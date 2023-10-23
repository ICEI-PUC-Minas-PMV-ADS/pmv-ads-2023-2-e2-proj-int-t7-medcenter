using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models {
    [Table("Exames")]
    public class Exame {
        [Key]
        public int Id { get; set; }

        public Paciente Paciente { get; set; }

        [Required(ErrorMessage ="Informe o tipo de exame.")]
        public TipoExame TipoExame { get; set; }



    }

     public enum TipoExame {
        Hemograma,
        Tomografia,
        Ultrassom,
        Radiografia
    }

    public enum Paciente {

    }
}
