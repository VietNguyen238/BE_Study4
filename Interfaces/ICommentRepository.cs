using be_study4.Dtos.Comment;
using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment CommentModel);
        Task<Comment?> UpdateAsync(int id, UpdateCommentDto update);
        Task<Comment?> DeleteAsync(int id);
    }
}