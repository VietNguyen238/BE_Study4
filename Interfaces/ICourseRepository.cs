using be_study4.Dtos.Course;
using be_study4.Helpers;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync(CourseQueryObject courseQuery);
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course CourseModel);
        Task<Course?> UpdateAsync(int id, UpdateCourseDto update);
        Task<Course?> DeleteAsync(int id);
    }
}