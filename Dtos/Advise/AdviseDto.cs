namespace be_study4.Dtos.Advise
{
    public class AdviseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;

    }
}