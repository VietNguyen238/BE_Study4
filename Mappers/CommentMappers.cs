using be_study4.Dtos.Comment;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                UserId = commentModel.UserId,
                ExamTopicId = commentModel.ExamTopicId,
                CreateOn = commentModel.CreateOn
            };
        }

        public static Comment ToCreateCommentDto(this CreateCommentDto createCommentDto, int userId, int examTopicId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                UserId = userId,
                ExamTopicId = examTopicId
            };
        }

        public static Comment ToUpdateCommentDto(this UpdateCommentDto updateCommentDto, int userId, int examTopicId)
        {
            return new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
                UserId = userId,
                ExamTopicId = examTopicId
            };
        }
    }
}