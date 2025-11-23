using PolicyNotesService.Api.Models;

namespace PolicyNotesService.Api.Services
{
    public interface IPolicyNoteService
    {
        Task<PolicyNote> AddNoteAsync(string policyNumber, string note);
        Task<List<PolicyNote>> GetNotesAsync();
        Task<PolicyNote?> GetNoteByIdAsync(int id);
    }
}
