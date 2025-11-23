using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Api.Data;
using PolicyNotesService.Api.Dtos;
using PolicyNotesService.Api.Repositories;
using PolicyNotesService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<PolicyNotesDbContext>(options =>
    options.UseInMemoryDatabase("PolicyNotesDb"));

builder.Services.AddScoped<IPolicyNoteRepository, PolicyNoteRepository>();
builder.Services.AddScoped<IPolicyNoteService, PolicyNoteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Group: /notes
var notesGroup = app.MapGroup("/notes");

// POST /notes
notesGroup.MapPost("/", async (PolicyNoteCreateDto dto, IPolicyNoteService service) =>
{
    if (string.IsNullOrWhiteSpace(dto.PolicyNumber) || string.IsNullOrWhiteSpace(dto.Note))
    {
        return Results.BadRequest("PolicyNumber and Note are required.");
    }

    var created = await service.AddNoteAsync(dto.PolicyNumber, dto.Note);

    return Results.Created($"/notes/{created.Id}", created);
});

// GET /notes
notesGroup.MapGet("/", async (IPolicyNoteService service) =>
{
    var notes = await service.GetNotesAsync();
    return Results.Ok(notes);
});

// GET /notes/{id}
notesGroup.MapGet("/{id:int}", async (int id, IPolicyNoteService service) =>
{
    var note = await service.GetNoteByIdAsync(id);
    if (note is null)
        return Results.NotFound();

    return Results.Ok(note);
});

app.Run();

// Needed so WebApplicationFactory<Program> can find this type in tests.
public partial class Program { }
