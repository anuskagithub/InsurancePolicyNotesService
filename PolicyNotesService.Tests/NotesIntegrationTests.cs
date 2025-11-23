using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using PolicyNotesService.Api.Dtos;
using Xunit;

namespace PolicyNotesService.Tests
{
    public class NotesIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public NotesIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_Notes_Should_Return_201_Created()
        {
            // Arrange
            var dto = new PolicyNoteCreateDto
            {
                PolicyNumber = "POL-100",
                Note = "First note"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/notes", dto);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Get_Notes_Should_Return_200_OK()
        {
            // Ensure there is at least one note
            await _client.PostAsJsonAsync("/notes", new PolicyNoteCreateDto
            {
                PolicyNumber = "POL-200",
                Note = "Some note"
            });

            // Act
            var response = await _client.GetAsync("/notes");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Note_By_Id_Should_Return_200_When_Found()
        {
            // Arrange - create a note first
            var postResponse = await _client.PostAsJsonAsync("/notes", new PolicyNoteCreateDto
            {
                PolicyNumber = "POL-300",
                Note = "Note for id test"
            });

            // Read created note
            var created = await postResponse.Content.ReadFromJsonAsync<PolicyNoteResponse>();

            // Act
            var getResponse = await _client.GetAsync($"/notes/{created!.Id}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
        }

        [Fact]
        public async Task Get_Note_By_Id_Should_Return_404_When_Missing()
        {
            // Arrange: some id that likely doesn't exist
            var response = await _client.GetAsync("/notes/99999");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // Small local DTO just for reading response in tests
        private class PolicyNoteResponse
        {
            public int Id { get; set; }
            public string PolicyNumber { get; set; } = string.Empty;
            public string Note { get; set; } = string.Empty;
        }
    }
}


