namespace be_study4.Dtos.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ExamSectionId { get; set; }
    }
}