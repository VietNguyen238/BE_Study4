using be_study4.Data;
using be_study4.Dtos.Comment;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
            await _context.Comments.AddAsync(CommentModel);
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateDto)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (Comment == null)
            {
                return null;
            }

            Comment.Title = updateDto.Title;
            Comment.Content = updateDto.Content;

            await _context.SaveChangesAsync();
            return Comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);


            if (Comment == null)
            {
                return null;
            }

            _context.Remove(Comment);
            await _context.SaveChangesAsync();
            return Comment;
        }
    }
}