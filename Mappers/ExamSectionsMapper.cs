using be_study4.Dtos.ExamSection;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class ExamSectionMappers
    {
        public static ExamSectionDto ToExamSectionDto(this ExamSection examSectionModel)
        {
            return new ExamSectionDto
            {
                Id = examSectionModel.Id,
                Title = examSectionModel.Title,
                ExamTopicId = examSectionModel.ExamTopicsId,
                Questions = examSectionModel.Questions.Select(s => s.ToQuestionDto()).ToList(),
            };
        }

        public static ExamSection ToCreateExamSectionDto(this CreateExamSectionDto createExamSectionDto, int examTopicsId)
        {
            return new ExamSection
            {
                Title = createExamSectionDto.Title,
                ExamTopicsId = examTopicsId
            };
        }

        public static ExamSection ToUpdateExamSectionDto(this UpdateExamSectionDto updateExamSectionDto, int examTopicsId)
        {
            return new ExamSection
            {
                Title = updateExamSectionDto.Title,
                ExamTopicsId = examTopicsId
            };
        }
    }
}