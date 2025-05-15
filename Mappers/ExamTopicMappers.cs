using be_study4.Dtos.ExamTopic;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class ExamTopicMappers
    {
        public static ExamTopicDto ToExamTopicDto(this ExamTopic examTopicModel)
        {
            return new ExamTopicDto
            {
                Id = examTopicModel.Id,
                Title = examTopicModel.Title,
                Time = examTopicModel.Time,
                Person = examTopicModel.Person,
                UserId = examTopicModel.UserId,
                Comments = examTopicModel.Comments.Select(s => s.ToCommentDto()).ToList(),
                ExamSections = examTopicModel.ExamSections.Select(s => s.ToExamSectionDto()).ToList(),
            };
        }

        public static ExamTopic ToCreateExamTopicDto(this CreateExamTopicDto createExamTopicDto, int userId)
        {
            return new ExamTopic
            {
                Title = createExamTopicDto.Title,
                Time = createExamTopicDto.Time,
                Person = createExamTopicDto.Person,
                UserId = userId
            };
        }

        public static ExamTopic ToUpdateExamTopicDto(this UpdateExamTopicDto updateExamTopicDto, int userId)
        {
            return new ExamTopic
            {
                Title = updateExamTopicDto.Title,
                Time = updateExamTopicDto.Time,
                Person = updateExamTopicDto.Person,
                UserId = userId
            };
        }
    }
}