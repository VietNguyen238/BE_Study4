using be_study4.Dtos.Advise;
using be_study4.Dtos.Comment;
using be_study4.Dtos.Course;
using be_study4.Dtos.ExamTopic;

namespace be_study4.Dtos.User
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public required List<ExamTopicDto> ExamTopics { get; set; }
        public required List<CourseDto> Courses { get; set; }
        public required List<AdviseDto> Advises { get; set; }
        public required List<CommentDto> Comments { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}