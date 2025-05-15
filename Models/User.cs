using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<ExamTopic> ExamTopics { get; set; } = new List<ExamTopic>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Advise> Advises { get; set; } = new List<Advise>();
    }
}