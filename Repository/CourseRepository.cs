using be_study4.Data;
using be_study4.Dtos.Course;
using be_study4.Helpers;
using be_study4.Interfaces;
using be_study4.Models;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllAsync(CourseQueryObject courseQuery)
        {
            var courses = _context.Courses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(courseQuery.Category))
            {
                courses = courses.Where(s => s.Category.Contains(courseQuery.Category));
            }
            return await courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Course> CreateAsync(Course CourseModel)
        {
            // Check if user exists
            var userExists = await _context.Users.AnyAsync(u => u.Id == CourseModel.UserId);
            if (!userExists)
            {
                throw new InvalidOperationException("User not found");
            }

            await _context.Courses.AddAsync(CourseModel);
            await _context.SaveChangesAsync();
            return CourseModel;
        }

        public async Task<Course?> UpdateAsync(int id, UpdateCourseDto updateDto)
        {
            var Course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (Course == null)
            {
                return null;
            }

            Course.Title = updateDto.Title;
            Course.Category = updateDto.Category;
            Course.NewPrice = updateDto.NewPrice;
            Course.Price = updateDto.Price;

            await _context.SaveChangesAsync();
            return Course;
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            var Course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (Course == null)
            {
                return null;
            }

            _context.Remove(Course);
            await _context.SaveChangesAsync();
            return Course;
        }
    }
}