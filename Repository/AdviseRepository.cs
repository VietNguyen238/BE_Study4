using be_study4.Data;
using be_study4.Dtos.Advise;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Repository
{
    public class AdviseRepository : IAdviseRepository
    {
        private readonly ApplicationDBContext _context;
        public AdviseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Advise>> GetAllAsync()
        {
            return await _context.Advises.ToListAsync();
        }

        public async Task<Advise?> GetByIdAsync(int id)
        {
            return await _context.Advises.FindAsync(id);
        }

        public async Task<Advise> CreateAsync(Advise AdviseModel)
        {
            await _context.Advises.AddAsync(AdviseModel);
            await _context.SaveChangesAsync();
            return AdviseModel;
        }
    }
}