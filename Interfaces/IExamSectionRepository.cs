using be_study4.Dtos.ExamSection;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface IExamSectionRepository
    {
        Task<List<ExamSection>> GetAllAsync();
        Task<ExamSection?> GetByIdAsync(int id);
        Task<ExamSection> CreateAsync(ExamSection examSExamSectionModel);
        Task<ExamSection?> UpdateAsync(int id, UpdateExamSectionDto update);
        Task<ExamSection?> DeleteAsync(int id);
    }
}