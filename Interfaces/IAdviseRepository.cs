using be_study4.Dtos.Advise;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface IAdviseRepository
    {
        Task<List<Advise>> GetAllAsync();
        Task<Advise?> GetByIdAsync(int id);
        Task<Advise> CreateAsync(Advise AdviseModel);
    }
}