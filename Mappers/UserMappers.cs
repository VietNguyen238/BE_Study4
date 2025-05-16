using be_study4.Dtos.User;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Avatar = userModel.Avatar,
                ExamTopics = userModel.ExamTopics.Select(s => s.ToExamTopicDto()).ToList(),
                Advises = userModel.Advises.Select(s => s.ToAdviseDto()).ToList(),
                Comments = userModel.Comments.Select(s => s.ToCommentDto()).ToList(),
                Courses = userModel.Courses.Select(s => s.ToCourseDto()).ToList(),
                CreateOn = userModel.CreateOn
            };
        }

        public static User ToRegisterDto(this RegisterDto registerDto)
        {
            return new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Avatar = registerDto.Avatar
            };
        }

        public static User ToUpdateUserDto(this UpdateUserDto updateUserDto)
        {
            return new User
            {
                Avatar = updateUserDto.Avatar
            };
        }
    }
}