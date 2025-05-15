using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.Advise
{
    public class CreateAdviseDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Phone must be 3 character")]
        [MaxLength(255, ErrorMessage = "Phone cannot be over 255 character")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Subject { get; set; } = string.Empty;
    }
}