using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace medcenter_backend.Models {
    [Table("Exames")]
    public class Exame {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Exame.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe a Descricao do Exame.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}