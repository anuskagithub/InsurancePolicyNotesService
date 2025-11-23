using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Api.Data;
using PolicyNotesService.Api.Models;

namespace PolicyNotesService.Api.Repositories
{
    public class PolicyNoteRepository : IPolicyNoteRepository
    {
        private readonly PolicyNotesDbContext _context;

        public PolicyNoteRepository(PolicyNotesDbContext context)
        {
            _context = context;
        }

        public async Task<PolicyNote> AddAsync(PolicyNote note)
        {
            _context.PolicyNotes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public Task<List<PolicyNote>> GetAllAsync()
        {
            return _context.PolicyNotes.ToListAsync();
        }

        public Task<PolicyNote?> GetByIdAsync(int id)
        {
            return _context.PolicyNotes.FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
