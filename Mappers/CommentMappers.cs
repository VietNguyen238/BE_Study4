using be_study4.Dtos.Comment;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment CommentModel)
        {
            return new CommentDto
            {
                Id = CommentModel.Id,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                UserId = CommentModel.UserId
            };
        }

        public static Comment ToCreateCommentDto(this CreateCommentDto createCommentDto, int userId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                UserId = userId
            };
        }

        public static Comment ToUpdateCommentDto(this UpdateCommentDto updateCommentDto, int userId)
        {
            return new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
                UserId = userId
            };
        }
    }
}