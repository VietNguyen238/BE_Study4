using be_study4.Data;
using be_study4.Dtos.Question;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question> CreateAsync(Question QuestionModel)
        {
            await _context.Questions.AddAsync(QuestionModel);
            await _context.SaveChangesAsync();
            return QuestionModel;
        }

        public async Task<Question?> UpdateAsync(int id, UpdateQuestionDto updateDto)
        {
            var Question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);

            if (Question == null)
            {
                return null;
            }

            Question.Title = updateDto.Title;

            await _context.SaveChangesAsync();
            return Question;
        }

        public async Task<Question?> DeleteAsync(int id)
        {
            var Question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);


            if (Question == null)
            {
                return null;
            }

            _context.Remove(Question);
            await _context.SaveChangesAsync();
            return Question;
        }
    }
}