# Day 35: JWT Authentication Theory and Middleware Pipelines

Welcome to my Day 35 training overview! Today, I studied how modern web APIs implement secure access control using JSON Web Tokens (JWT). This marks a significant shift from stateful session cookies to a stateless token-based approach.

---

## 1. Architectural Jump: Stateful Sessions vs. Stateless Tokens

We contrasted cookies with tokens to understand why RESTful APIs rely on JWTs:

*   **Stateful Session Management (Cookies):**
    *   The server generates a session ID, stores it in database/memory, and sends it to the browser as a cookie.
    *   On every request, the server must look up this ID in its database/memory to confirm who the user is.
    *   *Drawback:* Hard to scale horizontally when multiple servers are running.
*   **Stateless Token Authorization (JWT):**
    *   The server generates a self-contained token containing user details and signs it using a cryptographic key.
    *   The client stores this token (e.g., in local storage) and attaches it in the `Authorization: Bearer <token>` header of every API call.
    *   The server verifies the signature mathematically without looking up databases or managing session states.
    *   *Advantage:* Extremely fast, highly scalable, and perfectly suited for microservice architectures.

---

## 2. Local Development Connection Parameters

To connect our authentication service to the database during local sandbox development, we use this standard connection string format:

```text
Server=(localdb)\MSSQLLocalDB;Database=AuthIdentityDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;
```

*   **Trusted_Connection=True:** Connects using our current Windows credentials (no hardcoded credentials required in configuration).
*   **Encrypt=True:** Forces network encryption between our web application and the database server.
*   **TrustServerCertificate=True:** Prevents connection handshake errors due to untrusted self-signed SSL/TLS certificates used in local developer boxes.

---

## 3. Directory Layout Check

Here is the folder structure for today's JWT authentication theory and pipeline registration exercises:

```
Module-07-Devops/
└── Day-35-JWT-Authentication/
    ├── README.md
    ├── Jwt_Authentication_Theory_Notes.md
    ├── appsettings.json
    └── Program_Pipeline.cs
```

---

## 4. Repository Tracking
*   Project Repository: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
