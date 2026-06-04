# Day 35: JWT Authentication Theory and Token Anatomy

Hey! Today was all about learning how JWT (JSON Web Tokens) works. In our previous sessions, we used cookies, but today we moved on to token-based security which is standard for modern API development. Here are my notes on how it works under the hood.

---

## 1. Why Modern APIs Use JWT

When a mobile app or frontend website talks to a backend database, the server needs to make sure the user is allowed to perform operations (especially for sensitive things like banking, UPI, or shopping checkout). 

*   **The Old Way (Stateful Sessions):** The server stored a session ID in its memory and matched it against the client's cookie. This is tough to scale because if we run multiple servers, we have to synchronize session data across all of them.
*   **The JWT Way (Stateless Tokens):** Instead of saving user state on the server or looking up the database on every single API request, the server issues a signed JSON Web Token (JWT) when the user logs in. 
*   **Student Reminder:** This token acts like a secure digital ID card. It contains the user's details (like their username and role), it is signed using a secret key, and the client holds onto it. Whenever the client calls the API, they just show the token. The server simply validates the signature—no expensive database lookups needed!

---

## 2. Anatomy of a JSON Web Token

A JWT looks like a long, messy string separated by two dots (`xxxxx.yyyyy.zzzzz`). Those dots split the token into three distinct parts:

| Token Component | What it Contains & Why it's There |
| :--- | :--- |
| **Header** | Specifies the metadata for the token. It tells the server what type of token it is (`JWT`) and which cryptographic algorithm (like `HS256`) was used to sign it. |
| **Payload** | The meat of the token. It contains the actual user attributes, claims (like `username`, `roles`, or `EmployeeNumber`), and token metadata like the expiration timestamp (`exp`). |
| **Signature** | The security guard of the token. It is calculated by taking the encoded Header, the encoded Payload, and combining them with a secret key known only to the server. |

*   *Trainee Study Tip:* The signature part mathematically verifies that nobody has messed with our payload string on the way. If a user tries to change their role from "User" to "Admin" in the payload, the signature will no longer match, and our API will reject it instantly!

---

## 3. The Authentication Middleware Flow

Here is the step-by-step lifecycle of how a user accesses a protected API resource in our lab:

1.  **User Login:** The user enters their username and password in the client app.
2.  **Credentials Verified:** The server verifies these credentials against the database.
3.  **JWT Generated:** The server creates a JWT containing the user's identity details and signs it using our private key.
4.  **Token Sent to Client:** The server sends the JWT back to the client in the HTTP response body.
5.  **Stored on Client:** The client application saves the token locally (e.g., in `localStorage` or `sessionStorage`).
6.  **Sent in Authorization Header:** For every subsequent request, the client attaches the token in the headers as: `Authorization: Bearer <token_string>`.
7.  **Server Validates Token:** The ASP.NET Core middleware intercepts the request, reads the header, and checks if the token is expired and if the signature is authentic.
8.  **Access Granted:** Once validated, the framework extracts the user's claims and allows the request to reach the protected controller action.
