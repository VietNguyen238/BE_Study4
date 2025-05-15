using be_study4.Dtos.Comment;
using be_study4.Dtos.ExamSection;

namespace be_study4.Dtos.ExamTopic
{
    public class ExamTopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Time { get; set; }
        public int Person { get; set; }
        public int UserId { get; set; }
        public required List<ExamSectionDto> ExamSections { get; set; }
        public required List<CommentDto> Comments { get; set; }
    }
}