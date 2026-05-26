# Fiddler Testing and Debugging Notes

This document provides a summary of testing and monitoring the Book Store REST API using Fiddler.

## 1. Monitored Requests in Fiddler

Fiddler was configured to capture localhost traffic to inspect the HTTP request and response cycles. 

### Capturing Localhost Traffic
Because .NET Core default settings use HTTPS on localhost, the Fiddler Root Certificate was trusted to decrypt HTTPS tunnel traffic. Requests were routed to the local development port.

## 2. Tested API Endpoints and Status Codes

The CRUD operations were fully tested, and the HTTP status codes were validated according to REST design principles.

### GET Operations (Status 200 OK)
* **GET `/api/books`**: Retrieved all books with associated author names. Status code: 200 OK.
* **GET `/api/authors`**: Retrieved all authors. Status code: 200 OK.
* **GET `/api/books/1`**: Retrieved Book ID 1. Status code: 200 OK.
* **GET `/api/books/999`**: Retrieved an invalid book ID. Status code: 404 Not Found (returned JSON error description).

### POST Operations (Status 201 Created)
* **POST `/api/authors`**: Added a new author.
  * *Request Body:*
    ```json
    {
      "name": "Stephen King",
      "biography": "Legendary author of horror novels."
    }
    ```
  * *Response:* Status code 201 Created. The Location header contained the absolute URI to `/api/authors/4`.
* **POST `/api/books`**: Added a new book linked to Author 1. Status code: 201 Created.

### PUT Operations (Status 200 OK)
* **PUT `/api/books/1`**: Modified Book ID 1.
  * *Request Body:*
    ```json
    {
      "id": 1,
      "title": "Harry Potter and the Philosopher's Stone",
      "genre": "Fantasy",
      "publicationYear": 1997,
      "price": 19.99,
      "authorId": 1
    }
    ```
  * *Response:* Status code 200 OK with the updated book record.
* **PUT `/api/books/1` (ID Mismatch)**: Sent Book ID 1 in URI but ID 2 in JSON body. Status code: 400 Bad Request.

### DELETE Operations (Status 200 OK)
* **DELETE `/api/books/2`**: Deleted Book ID 2. Status code: 200 OK.
* **DELETE `/api/books/999`**: Attempted to delete a non-existing book. Status code: 404 Not Found.

## 3. Checked JSON Responses and Headers

* **Content-Type Header:** Verified that all successful responses returned the `application/json; charset=utf-8` header.
* **Validation Errors (Status 400 Bad Request):** Sent a POST request without a book title. Checked the response in Fiddler and verified that it returned standard JSON validation messages matching the model annotations.
