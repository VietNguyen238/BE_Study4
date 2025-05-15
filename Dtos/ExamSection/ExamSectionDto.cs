using be_study4.Dtos.Question;

namespace be_study4.Dtos.ExamSection
{
    public class ExamSectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ExamTopicId { get; set; }
        public required List<QuestionDto> Questions { get; set; }


    }
}