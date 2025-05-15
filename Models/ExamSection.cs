using System.ComponentModel.DataAnnotations.Schema;

namespace be_study4.Models
{
    [Table("ExamSections")]
    public class ExamSection
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ExamTopicsId { get; set; }
        public ExamTopic? ExamTopics { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}