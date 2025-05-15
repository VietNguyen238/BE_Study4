using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("Questions")]
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ExamSectionId { get; set; }
        public ExamSection? ExamSection { get; set; }
    }
}