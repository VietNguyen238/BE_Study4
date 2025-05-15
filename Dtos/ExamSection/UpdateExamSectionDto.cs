using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.ExamSection
{
    public class UpdateExamSectionDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(255, ErrorMessage = "Title cannot be over 255 characters")]
        public string Title { get; set; } = string.Empty;
    }
}