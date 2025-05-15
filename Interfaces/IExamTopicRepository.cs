using be_study4.Dtos.ExamTopic;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface IExamTopicRepository
    {
        Task<List<ExamTopic>> GetAllAsync();
        Task<ExamTopic?> GetByIdAsync(int id);
        Task<ExamTopic> CreateAsync(ExamTopic examTopicModel);
        Task<ExamTopic?> UpdateAsync(int id, UpdateExamTopicDto update);
        Task<ExamTopic?> DeleteAsync(int id);
    }
}