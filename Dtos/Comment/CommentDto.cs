namespace be_study4.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int ExamTopicId { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;

    }
}