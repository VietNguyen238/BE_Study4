using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int ExamTopicId { get; set; }
        public ExamTopic? ExamTopic { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}