# .NET Web Architecture & Security Reference

## The Request-Response Pipeline

The ASP.NET Core framework is built upon a modular **Middleware Pipeline**. Every HTTP request sent to the server travels through a bidirectional sequence of components before reaching the endpoint logic.

### Middleware Execution Flow
1.  **Request Entry**: The web server (Kestrel/IIS) receives the HTTP request.
2.  **Middleware Chain**: The request passes through ordered middleware (e.g., Exception Handling -> HSTS -> HTTPS Redirection -> Static Files -> Routing -> Authentication -> Authorization).
3.  **Endpoint Execution**: The specific controller or handler processes the request.
4.  **Response Exit**: The response travels back through the same middleware chain in reverse order, allowing for response modification (e.g., adding security headers).

## Secure Coding Guidelines

To ensure applications are "Secure-by-Design," the following standards are mandatory across all implementations:

### 1. Input Validation
*   **Policy**: Never trust client-side data.
*   **Implementation**: Utilize Data Annotations and Fluent Validation to enforce strict schema requirements before processing.
*   **Requirement**: Sanitize all inputs to prevent Cross-Site Scripting (XSS) and injection attacks.

### 2. Database Security (Parameterized Queries)
*   **Policy**: Prevention of SQL Injection is a non-negotiable requirement.
*   **Implementation**: Use Object-Relational Mappers (ORMs) like Entity Framework Core or parameterized queries in ADO.NET. 
*   **Requirement**: Hard-coded string concatenation for SQL commands is strictly prohibited.

### 3. Transport Layer Security (HTTPS)
*   **Policy**: All data in transit must be encrypted.
*   **Implementation**: Enforce `UseHttpsRedirection` and `HSTS` (HTTP Strict Transport Security) in the application startup.
*   **Requirement**: Development and production environments must utilize SSL/TLS certificates.

### 4. Cryptographic Hashing
*   **Policy**: Sensitive data (passwords, PII) must never be stored in plaintext.
*   **Implementation**: Utilize industry-standard hashing algorithms with unique salts for every entry.
