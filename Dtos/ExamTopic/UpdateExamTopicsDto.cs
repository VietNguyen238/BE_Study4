using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.ExamTopic
{
    public class UpdateExamTopicDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(255, ErrorMessage = "Title cannot be over 255 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Time { get; set; }
        [Required]
        public int Person { get; set; }
    }
}