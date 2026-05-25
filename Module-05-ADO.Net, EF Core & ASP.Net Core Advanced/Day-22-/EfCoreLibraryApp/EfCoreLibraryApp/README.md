# EF Core Library App

A simple ASP.NET Core MVC application demonstrating Entity Framework Core concepts including Code First and Database First approaches.

## Project Purpose

This application manages a library system with books, authors, and genres. It covers both EF Core Code First and Database First workflows as part of the Wipro training assignment.

## EF Core Code First

- Entities: Book, Author, Genre, BookGenre (join table)
- Relationships configured using Fluent API in LibraryContext
- One-to-many: Author -> Books
- Many-to-many: Book <-> Genre through BookGenre
- Seed data included in OnModelCreating

## EF Core Database First

- Simulates scaffolding from an existing database
- DbFirstBook model in DatabaseFirstModels folder
- DbFirstLibraryContext configured separately
- SQL scripts in DatabaseScripts folder show what the existing database would look like

## SQL Scripts (Execution Order)

1. `DatabaseScripts/01_CreateExistingLibraryDatabase.sql` - Creates the database and tables
2. `DatabaseScripts/02_SampleData.sql` - Inserts sample book records

Note: The app uses InMemory database for demo purposes, so you do not need to run these scripts to test the app. They are included to show what the real database schema would look like.

## Migration Commands (for reference)

If using a real SQL Server database instead of InMemory:

```
dotnet ef migrations add InitialCreate --context LibraryContext
dotnet ef database update --context LibraryContext
dotnet ef dbcontext scaffold "Server=.;Database=ExistingLibraryDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseFirstModels
```

## How to Run

```
cd EfCoreLibraryApp
dotnet run
```

The app will start on https://localhost:5001 or http://localhost:5000 (check console output for the actual port).

## Routes to Test

| Route | Description |
|---|---|
| / | Home page |
| /Books | Books list (Code First CRUD) |
| /Books/Create | Add a new book |
| /Books/Edit/{id} | Edit a book |
| /Books/Delete/{id} | Delete a book |
| /Genres | Genres list (Code First CRUD) |
| /Authors | Authors list (Code First CRUD) |
| /DatabaseFirstBooks | Database First books (CRUD) |
| /LibraryQuery | EF Core query demonstrations |

## Requirement Checklist

- [x] EF Core Code First setup with Fluent API
- [x] Book, Author, Genre, BookGenre entities
- [x] One-to-many relationship (Author -> Books)
- [x] Many-to-many relationship (Book <-> Genre via BookGenre)
- [x] CRUD operations for Books, Authors, Genres
- [x] Database First approach with separate context
- [x] SQL scripts for existing database
- [x] Efficient queries with Include, ThenInclude, AsNoTracking
- [x] LibraryQuery page showing query results
- [x] Basic Bootstrap UI

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (InMemory provider for demo)
- Bootstrap 5
