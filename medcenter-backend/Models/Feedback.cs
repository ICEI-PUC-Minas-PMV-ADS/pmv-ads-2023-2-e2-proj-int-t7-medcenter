using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace medcenter_backend.Models
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? Answer {  get; set; }
        [StringLength(500)]

        public string Comment  { get; set; }
        [StringLength(500)]
        public string FullName { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
