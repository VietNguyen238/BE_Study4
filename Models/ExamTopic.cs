using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("ExamTopics")]
    public class ExamTopic
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Time { get; set; }
        public int Person { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<ExamSection> ExamSections { get; set; } = new List<ExamSection>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}