using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.Course
{
    public class UpdateCourseDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(255, ErrorMessage = "Title cannot be over 255 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Category must be 2 characters")]
        [MaxLength(255, ErrorMessage = "Category cannot be over 255 characters")]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }
        [Required]
        public int NewPrice { get; set; }
    }
}