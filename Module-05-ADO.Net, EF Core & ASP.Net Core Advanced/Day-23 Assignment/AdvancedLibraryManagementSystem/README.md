# Advanced Library Management System

ASP.NET Core MVC project demonstrating the Repository Design Pattern with EF Core and AJAX-based CRUD operations.

## What this project covers

- Generic repository pattern with async CRUD (Add, Update, Delete, GetById, GetAll)
- Entity-specific repositories: BookRepository, AuthorRepository, GenreRepository
- EF Core with one-to-many (Author -> Books) and many-to-many (Book <-> Genre) relationships
- LINQ queries with filtering, sorting, eager loading (Include/ThenInclude), and pagination
- AJAX form submissions with modals - no full page reloads for create/edit/delete
- Success and error messages shown after each AJAX operation

## Setup

The app uses an InMemory database by default, so no SQL Server setup is needed to run it.

To switch to SQL Server, update `Program.cs` and replace `UseInMemoryDatabase` with `UseSqlServer(connectionString)`, then run:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The SQL scripts in `DatabaseScripts/` show the expected schema.

## Run

```
cd AdvancedLibraryManagementSystem
dotnet run
```

## Routes

| Route | Description |
|---|---|
| / | Home |
| /Books | Books list with search and pagination |
| /Authors | Authors list |
| /Genres | Genres list |

All create/edit/delete operations happen via AJAX modal dialogs.

## Requirements covered

- Generic IRepository interface
- BookRepository, AuthorRepository, GenreRepository
- Async methods throughout
- EF Core relationships and navigation properties
- Filtering, sorting, pagination with LINQ
- AJAX create, edit, delete with JSON responses
- Error handling with user-friendly messages
