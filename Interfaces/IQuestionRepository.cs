using be_study4.Dtos.Question;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id);
        Task<Question> CreateAsync(Question QuestionModel);
        Task<Question?> UpdateAsync(int id, UpdateQuestionDto update);
        Task<Question?> DeleteAsync(int id);
    }
}