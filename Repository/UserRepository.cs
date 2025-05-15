using be_study4.Data;
using be_study4.Dtos.User;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(i => i.ExamTopics)
                    .ThenInclude(et => et.ExamSections)
                        .ThenInclude(es => es.Questions)
                .Include(i => i.ExamTopics)
                    .ThenInclude(et => et.Comments)
                .Include(i => i.Comments)
                .Include(i => i.Courses)
                .Include(s => s.Advises)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(i => i.ExamTopics)
                    .ThenInclude(et => et.ExamSections)
                        .ThenInclude(es => es.Questions)
                .Include(i => i.ExamTopics)
                    .ThenInclude(et => et.Comments)
                .Include(i => i.Comments)
                .Include(i => i.Courses)
                .Include(s => s.Advises)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> RegisterAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> FindByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) return null;
            return user;
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserDto updateDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;
            user.Avatar = updateDto.Avatar;
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}