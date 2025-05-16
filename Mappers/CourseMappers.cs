using be_study4.Dtos.Course;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class CourseMappers
    {
        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                Id = courseModel.Id,
                Title = courseModel.Title,
                Category = courseModel.Category,
                NewPrice = courseModel.NewPrice,
                Price = courseModel.Price,
                UserId = courseModel.UserId,
                Image = courseModel.Image,
                CreateOn = courseModel.CreateOn
            };
        }

        public static Course ToCreateCourseDto(this CreateCourseDto createCourseDto, int userId, string image)
        {
            return new Course
            {
                Title = createCourseDto.Title,
                Category = createCourseDto.Category,
                NewPrice = createCourseDto.NewPrice,
                Price = createCourseDto.Price,
                Image = image,
                UserId = userId
            };
        }

        public static Course ToUpdateCourseDto(this UpdateCourseDto updateCourseDto, string image, int userId)
        {
            return new Course
            {
                Title = updateCourseDto.Title,
                Category = updateCourseDto.Category,
                NewPrice = updateCourseDto.NewPrice,
                Price = updateCourseDto.Price,
                Image = image,
                UserId = userId
            };
        }
    }
}