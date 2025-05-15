using be_study4.Data;
using be_study4.Dtos.ExamTopic;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class ExamTopicRepository : IExamTopicRepository
    {
        private readonly ApplicationDBContext _context;
        public ExamTopicRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ExamTopic>> GetAllAsync()
        {
            return await _context.ExamTopics.Include(s => s.ExamSections).Include(s => s.Comments).ToListAsync();
        }

        public async Task<ExamTopic?> GetByIdAsync(int id)
        {
            return await _context.ExamTopics.Include(s => s.ExamSections).Include(s => s.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExamTopic> CreateAsync(ExamTopic examTopicModel)
        {
            await _context.ExamTopics.AddAsync(examTopicModel);
            await _context.SaveChangesAsync();
            return examTopicModel;
        }

        public async Task<ExamTopic?> UpdateAsync(int id, UpdateExamTopicDto updateDto)
        {
            var examTopic = await _context.ExamTopics.FirstOrDefaultAsync(x => x.Id == id);

            if (examTopic == null)
            {
                return null;
            }

            examTopic.Title = updateDto.Title;
            examTopic.Time = updateDto.Time;
            examTopic.Person = updateDto.Person;

            await _context.SaveChangesAsync();
            return examTopic;
        }

        public async Task<ExamTopic?> DeleteAsync(int id)
        {
            var examTopic = await _context.ExamTopics.FirstOrDefaultAsync(x => x.Id == id);


            if (examTopic == null)
            {
                return null;
            }

            _context.Remove(examTopic);
            await _context.SaveChangesAsync();
            return examTopic;
        }
    }
}