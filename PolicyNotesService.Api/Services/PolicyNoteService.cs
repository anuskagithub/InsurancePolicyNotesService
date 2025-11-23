using PolicyNotesService.Api.Models;
using PolicyNotesService.Api.Repositories;

namespace PolicyNotesService.Api.Services
{
    public class PolicyNoteService : IPolicyNoteService
    {
        private readonly IPolicyNoteRepository _repository;

        public PolicyNoteService(IPolicyNoteRepository repository)
        {
            _repository = repository;
        }

        public Task<List<PolicyNote>> GetNotesAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<PolicyNote?> GetNoteByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<PolicyNote> AddNoteAsync(string policyNumber, string note)
        {
            var entity = new PolicyNote
            {
                PolicyNumber = policyNumber,
                Note = note
            };

            return await _repository.AddAsync(entity);
        }
    }
}
