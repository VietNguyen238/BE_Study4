using be_study4.Data;
using be_study4.Dtos.ExamSection;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class ExamSectionRepository : IExamSectionRepository
    {
        private readonly ApplicationDBContext _context;
        public ExamSectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ExamSection>> GetAllAsync()
        {
            return await _context.ExamSections.Include(x => x.Questions).ToListAsync();
        }

        public async Task<ExamSection?> GetByIdAsync(int id)
        {
            return await _context.ExamSections.Include(x => x.Questions).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ExamSection> CreateAsync(ExamSection examSeExamSectionModel)
        {
            await _context.ExamSections.AddAsync(examSeExamSectionModel);
            await _context.SaveChangesAsync();
            return examSeExamSectionModel;
        }

        public async Task<ExamSection?> UpdateAsync(int id, UpdateExamSectionDto updateDto)
        {
            var examSeExamSection = await _context.ExamSections.FirstOrDefaultAsync(x => x.Id == id);

            if (examSeExamSection == null)
            {
                return null;
            }

            examSeExamSection.Title = updateDto.Title;

            await _context.SaveChangesAsync();
            return examSeExamSection;
        }

        public async Task<ExamSection?> DeleteAsync(int id)
        {
            var examSeExamSection = await _context.ExamSections.FirstOrDefaultAsync(x => x.Id == id);


            if (examSeExamSection == null)
            {
                return null;
            }

            _context.Remove(examSeExamSection);
            await _context.SaveChangesAsync();
            return examSeExamSection;
        }
    }
}