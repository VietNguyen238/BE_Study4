using be_study4.Dtos.Question;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class QuestionMappers
    {
        public static QuestionDto ToQuestionDto(this Question questionModel)
        {
            return new QuestionDto
            {
                Id = questionModel.Id,
                Title = questionModel.Title,
                ExamSectionId = questionModel.ExamSectionId
            };
        }

        public static Question ToCreateQuestionDto(this CreateQuestionDto questionDto, int ExamSectionId)
        {
            return new Question
            {
                Title = questionDto.Title,
                ExamSectionId = ExamSectionId,
            };
        }

        public static Question ToUpdateQuestionDto(this UpdateQuestionDto questionDto, int ExamSectionId)
        {
            return new Question
            {
                Title = questionDto.Title,
                ExamSectionId = ExamSectionId
            };
        }
    }
}