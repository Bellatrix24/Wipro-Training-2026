# Fiddler Testing and Debugging Notes

This document provides a summary of testing and monitoring the Movie Catalog REST API using Fiddler.

## 1. Monitored Requests in Fiddler

Fiddler was configured to capture localhost traffic to inspect the HTTP request and response cycles. 

### Capturing Localhost Traffic
Because .NET Core default settings use HTTPS on localhost, the Fiddler Root Certificate was trusted to decrypt HTTPS tunnel traffic. Requests were routed to the local development port.

## 2. Tested API Endpoints and Status Codes

The CRUD operations were fully tested, and the HTTP status codes were validated according to REST design principles.

### GET Operations (Status 200 OK)
* **GET `/api/movies`**: Retreived all movies with associated director names. Status code: 200 OK.
* **GET `/api/directors`**: Retrieved all directors. Status code: 200 OK.
* **GET `/api/movies/1`**: Retrieved Movie ID 1 (Inception). Status code: 200 OK.
* **GET `/api/movies/999`**: Retrieved an invalid movie ID. Status code: 404 Not Found (returned JSON error description).

### POST Operations (Status 201 Created)
* **POST `/api/directors`**: Added a new director.
  * *Request Body:*
    ```json
    {
      "name": "Martin Scorsese",
      "bio": "Legendary director of crime dramas."
    }
    ```
  * *Response:* Status code 201 Created. The Location header contained the absolute URI to `/api/directors/4`.
* **POST `/api/movies`**: Added a new movie linked to Director 1. Status code: 201 Created.

### PUT Operations (Status 200 OK)
* **PUT `/api/movies/1`**: Modified Movie ID 1.
  * *Request Body:*
    ```json
    {
      "id": 1,
      "title": "Inception (Updated)",
      "genre": "Sci-Fi / Thriller",
      "releaseYear": 2010,
      "directorId": 1
    }
    ```
  * *Response:* Status code 200 OK with the updated movie record.
* **PUT `/api/movies/1` (ID Mismatch)**: Sent Movie ID 1 in URI but ID 2 in JSON body. Status code: 400 Bad Request.

### DELETE Operations (Status 200 OK)
* **DELETE `/api/movies/2`**: Deleted Movie ID 2 (Interstellar). Status code: 200 OK.
* **DELETE `/api/movies/999`**: Attempted to delete a non-existing movie. Status code: 404 Not Found.

## 3. Checked JSON Responses and Headers

* **Content-Type Header:** Verified that all successful responses returned the `application/json; charset=utf-8` header.
* **Validation Errors (Status 400 Bad Request):** Sent a POST request without a movie title. Checked the response in Fiddler and verified that it returned standard JSON validation messages matching the model annotations.
