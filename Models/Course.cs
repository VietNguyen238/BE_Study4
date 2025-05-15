using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? Image { get; set; }
        public User? User { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Price { get; set; }
        public int NewPrice { get; set; }
    }
}