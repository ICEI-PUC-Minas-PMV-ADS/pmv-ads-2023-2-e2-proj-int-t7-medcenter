using System.Drawing;

namespace medcenter_backend.Models
{
    public class FeedbackViewModel
    {
        public string Comment { get; set; }
        public String FullName { get; set; }
        public string Email { get; set; }
        public int? Select {  get; set; }
        public List<Answer> Answer {  get; set; }
    }
}
