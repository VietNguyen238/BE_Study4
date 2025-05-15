namespace be_study4.Dtos.Account
{
    public class NewUserDto
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string? Token { get; set; }
    }
}