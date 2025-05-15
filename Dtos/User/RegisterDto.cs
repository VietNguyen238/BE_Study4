using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string? Avatar { get; set; }
    }
}