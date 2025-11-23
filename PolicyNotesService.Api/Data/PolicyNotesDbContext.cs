using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Api.Models;

namespace PolicyNotesService.Api.Data
{
    public class PolicyNotesDbContext : DbContext
    {
        public PolicyNotesDbContext(DbContextOptions<PolicyNotesDbContext> options)
            : base(options)
        {
        }

        public DbSet<PolicyNote> PolicyNotes => Set<PolicyNote>();
    }
}

