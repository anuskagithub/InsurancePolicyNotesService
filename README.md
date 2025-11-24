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

## 🧪 Testing

Run All Tests (CLI)
From the solution root:
```
dotnet test
```
This will run both:
- Unit tests in PolicyNoteServiceTests.cs
- Integration tests in NotesIntegrationTests.cs

### Unit Tests (xUnit)
**File:** `PolicyNotesService.Tests/PolicyNoteServiceTests.cs`
#### Covers:
1. **Adding a note**
   - `AddNoteAsync_Should_Add_New_Note`
     - Uses `PolicyNotesDbContext` with InMemory provider
     - Verifies that:
       - `Id` is generated
       - `PolicyNumber` and `Note` match the input

2. **Retrieving notes**
   - `GetNotesAsync_Should_Return_Notes`
     - Adds 2 notes via the service
     - Verifies that `GetNotesAsync()` returns 2 items


### 🧪 Integration Tests (xUnit + WebApplicationFactory)

**File:** `PolicyNotesService.Tests/NotesIntegrationTests.cs`  
Uses `WebApplicationFactory<Program>` to spin up an in-memory test server and call the API endpoints just like a real client.

#### Covers:

1. **POST `/notes` returns `201 Created`**
   - Sends a JSON body with `policyNumber` and `note`
   - Asserts `StatusCode == 201 Created`

2. **GET `/notes` returns `200 OK`**
   - Ensures at least one note exists (via POST)
   - Calls `GET /notes`
   - Asserts `StatusCode == 200 OK`

3. **GET `/notes/{id}` returns `200 OK` when found**
   - Creates a note via POST
   - Reads the created `id` from the response
   - Calls `GET /notes/{id}`
   - Asserts `StatusCode == 200 OK`

4. **GET `/notes/{id}` returns `404 NotFound` when missing**
   - Calls `GET /notes/999999` (or another non-existing id)
   - Asserts `StatusCode == 404 NotFound`


