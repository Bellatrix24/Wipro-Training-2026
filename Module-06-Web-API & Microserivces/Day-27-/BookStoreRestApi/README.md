# Book Store REST API

A clean and simple ASP.NET Core Web API built for the Day 27 assignment. The application demonstrates RESTful API design principles, CRUD operations, resource associations, model validation, and error handling.

## Project Purpose

The purpose of this project is to develop a lightweight RESTful Web API using .NET 8. It manages a catalog of books and authors, links them through simple relational mappings, and validates all incoming data before updating the in-memory database. The API is designed for testing using Fiddler and Postman.

## API Routes Supported

The API exposes standard REST routes and returns appropriate HTTP status codes (200 OK, 201 Created, 400 Bad Request, 404 Not Found).

### Books Endpoints
* **GET `/api/books`**: Retrieve all books in the catalog.
* **GET `/api/books/{id}`**: Retrieve a specific book by ID.
* **POST `/api/books`**: Create a new book record (requires valid AuthorId).
* **PUT `/api/books/{id}`**: Update an existing book record (requires matching ID in URI and body).
* **DELETE `/api/books/{id}`**: Delete a book by ID.

### Authors Endpoints
* **GET `/api/authors`**: Retrieve all authors.
* **GET `/api/authors/{id}`**: Retrieve a specific author by ID.
* **POST `/api/authors`**: Create a new author.
* **PUT `/api/authors/{id}`**: Update an existing author's record.
* **DELETE `/api/authors/{id}`**: Delete an author by ID (and cascade delete their associated books).

### Associated Resource Endpoints
* **GET `/api/authors/{authorId}/books`**: Retrieve all books associated with a specific author.

## How to Run

1. Navigate to the Web API folder in the terminal:
   `BookStoreRestApi/BookStoreRestApi/`
2. Run the application:
   `dotnet run`
3. Access the API locally. Swagger testing UI will be available at:
   `https://localhost:5001/swagger` (or the dynamic HTTPS port displayed in the console).

## Postman and Fiddler Testing Summary

* **Postman Collection:** A pre-configured collection is provided at `PostmanCollection/bookstore-api-collection.json` containing requests for all CRUD routes and the association endpoint.
* **Fiddler Monitoring:** Detailed debugging and inspection notes are recorded inside `FiddlerNotes/fiddler-testing-notes.md`. Verification includes checking Content-Type headers, HTTP status codes, and model state validation messages.

## Requirement Checklist

* [x] Complete Books CRUD API
* [x] Complete Authors CRUD API
* [x] One-to-Many Book to Author association
* [x] RESTful associated resource endpoint (/api/authors/{authorId}/books)
* [x] Input Model validation (Title, Name, PublicationYear ranges)
* [x] Graceful error responses (JSON messages, Bad Request, Not Found checks)
* [x] Exported Postman JSON collection
* [x] Fiddler testing documentation
* [x] Standard SQL Setup script
