using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Api.Data;
using PolicyNotesService.Api.Repositories;
using PolicyNotesService.Api.Services;
using Xunit;

namespace PolicyNotesService.Tests
{
    public class PolicyNoteServiceTests
    {
        private PolicyNoteService CreateService(string dbName)
        {
            var options = new DbContextOptionsBuilder<PolicyNotesDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new PolicyNotesDbContext(options);
            var repo = new PolicyNoteRepository(context);
            return new PolicyNoteService(repo);
        }

        [Fact]
        public async Task AddNoteAsync_Should_Add_New_Note()
        {
            // Arrange
            var service = CreateService("AddNoteDb");

            // Act
            var created = await service.AddNoteAsync("POL123", "Test note");

            // Assert
            created.Id.Should().BeGreaterThan(0);
            created.PolicyNumber.Should().Be("POL123");
            created.Note.Should().Be("Test note");
        }

        [Fact]
        public async Task GetNotesAsync_Should_Return_Notes()
        {
            // Arrange
            var service = CreateService("GetNotesDb");
            await service.AddNoteAsync("P1", "Note1");
            await service.AddNoteAsync("P2", "Note2");

            // Act
            var notes = await service.GetNotesAsync();

            // Assert
            notes.Should().HaveCount(2);
        }
    }
}
