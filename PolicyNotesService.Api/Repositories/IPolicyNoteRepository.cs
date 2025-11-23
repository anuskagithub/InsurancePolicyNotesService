using PolicyNotesService.Api.Models;

namespace PolicyNotesService.Api.Repositories
{
    public interface IPolicyNoteRepository
    {
        Task<PolicyNote> AddAsync(PolicyNote note);
        Task<List<PolicyNote>> GetAllAsync();
        Task<PolicyNote?> GetByIdAsync(int id);
    }
}
