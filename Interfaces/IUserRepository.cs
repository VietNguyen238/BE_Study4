using be_study4.Dtos.User;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> RegisterAsync(User userModel);
        Task<User?> UpdateAsync(int id, UpdateUserDto updateDto);
        Task<User?> DeleteAsync(int id);
        Task<User?> FindByEmail(string email);
    }
}