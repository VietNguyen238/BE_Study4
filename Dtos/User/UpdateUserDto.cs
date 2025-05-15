using System.ComponentModel.DataAnnotations;

namespace be_study4.Dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        public string Avatar { get; set; } = string.Empty;
    }
}