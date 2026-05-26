# Movie Catalog REST API

A clean and simple ASP.NET Core Web API built for the Day 27 assignment. The application demonstrates RESTful API design principles, CRUD operations, resource associations, model validation, and error handling.

## Project Purpose

The purpose of this project is to develop a lightweight RESTful Web API using .NET 8. It manages a catalog of movies and directors, links them through simple relational mappings, and validates all incoming data before updating the in-memory database. The API is designed for testing using Fiddler and Postman.

## API Routes Supported

The API exposes standard REST routes and returns appropriate HTTP status codes (200 OK, 201 Created, 400 Bad Request, 404 Not Found).

### Movies Endpoints
* **GET `/api/movies`**: Retrieve all movies in the catalog.
* **GET `/api/movies/{id}`**: Retrieve a specific movie by ID.
* **POST `/api/movies`**: Create a new movie record (requires valid DirectorId).
* **PUT `/api/movies/{id}`**: Update an existing movie record (requires matching ID in URI and body).
* **DELETE `/api/movies/{id}`**: Delete a movie by ID.

### Directors Endpoints
* **GET `/api/directors`**: Retrieve all directors.
* **GET `/api/directors/{id}`**: Retrieve a specific director by ID.
* **POST `/api/directors`**: Create a new director.
* **PUT `/api/directors/{id}`**: Update an existing director's record.
* **DELETE `/api/directors/{id}`**: Delete a director by ID (and cascade delete their associated movies).

### Associated Resource Endpoints
* **GET `/api/directors/{directorId}/movies`**: Retrieve all movies associated with a specific director.

## How to Run

1. Navigate to the Web API folder in the terminal:
   `MovieCatalogRestApi/MovieCatalogRestApi/`
2. Run the application:
   `dotnet run`
3. Access the API locally. Swagger testing UI will be available at:
   `https://localhost:5001/swagger` (or the dynamic HTTPS port displayed in the console).

## Postman and Fiddler Testing Summary

* **Postman Collection:** A pre-configured collection is provided at `PostmanCollection/movie-catalog-api-collection.json` containing requests for all CRUD routes and the association endpoint.
* **Fiddler Monitoring:** Detailed debugging and inspection notes are recorded inside `FiddlerNotes/fiddler-testing-notes.md`. Verification includes checking Content-Type headers, HTTP status codes, and model state validation messages.

## Requirement Checklist

* [x] Complete Movies CRUD API
* [x] Complete Directors CRUD API
* [x] One-to-Many Movie to Director association
* [x] RESTful associated resource endpoint (/api/directors/{directorId}/movies)
* [x] Input Model validation (Title, Name, ReleaseYear ranges)
* [x] Graceful error responses (JSON messages, Bad Request, Not Found checks)
* [x] Exported Postman JSON collection
* [x] Fiddler testing documentation
* [x] Standard SQL Setup script
