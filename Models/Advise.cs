using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("Advises")]
    public class Advise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;

    }
}