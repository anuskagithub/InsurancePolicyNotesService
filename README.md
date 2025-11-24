# Insurance Policy Notes Service

A small microservice for an insurance company to **store and retrieve internal notes** for customer insurance policies.

The service is built with **.NET 8 Minimal APIs**, uses **EF Core InMemory** as the database, follows **Repository + Service** layers, and includes **unit tests** and **integration tests** using **xUnit**.

---

## 🎯 Objectives

1. Implement a microservice to manage policy notes:
   - Each note has: `id`, `policyNumber`, `note`.
   - Support basic CRUD-style read + create operations.
2. Use:
   - .NET 8 Minimal APIs  
   - EF Core InMemory Database  
   - Repository + Service layers
3. Test the application:
   - **Unit tests** for `PolicyNoteService`:
     - Adding a note
     - Retrieving notes
   - **Integration tests** using `WebApplicationFactory<Program>`:
     - `POST /notes` → `201 Created`
     - `GET /notes` → `200 OK`
     - `GET /notes/{id}` → `200 OK` when found, `404 NotFound` when missing

---

## 🛠️ Tech Stack

- **.NET 8**
- **ASP.NET Core Minimal APIs**
- **Entity Framework Core 8 (InMemory provider)**
- **xUnit** for unit & integration tests
- **Microsoft.AspNetCore.Mvc.Testing** for test host / `WebApplicationFactory<Program>`
- **Swagger / Swashbuckle** for API documentation & testing

---

## 📁 Project Structure

```text
.
├── PolicyNotesService.Api
│   ├── Data
│   │   └── PolicyNotesDbContext.cs
│   ├── Dtos
│   │   └── PolicyNoteCreateDto.cs
│   ├── Models
│   │   └── PolicyNote.cs
│   ├── Repositories
│   │   ├── IPolicyNoteRepository.cs
│   │   └── PolicyNoteRepository.cs
│   ├── Services
│   │   ├── IPolicyNoteService.cs
│   │   └── PolicyNoteService.cs
│   └── Program.cs
│
└── PolicyNotesService.Tests
    ├── PolicyNoteServiceTests.cs        # Unit tests
    └── NotesIntegrationTests.cs         # Integration tests (WebApplicationFactory<Program>)

```

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 / VS Code / Rider (any IDE that supports .NET 8)

### Clone the Repository
```
git clone <your-repo-url>.git
cd PolicyNotesService
```

### Run the API (from CLI)
```
cd PolicyNotesService.Api
dotnet run
```

The API will start on a port similar to:
```
https://localhost:7101
http://localhost:5101
```

Swagger UI
Open the browser at:
```
https://localhost:7101/swagger
```

