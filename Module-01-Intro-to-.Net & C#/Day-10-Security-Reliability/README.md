# Day 10: .NET Security & Reliability - Learning Log

Today I focused on two critical aspects of professional software development: **Security** (protecting data) and **Reliability** (handling errors and monitoring performance).

## Authentication vs. Authorization

Understanding the difference between these two is fundamental to security:

- **Authentication (Identity):** This is the process of verifying **who** a user is. 
  - *Analogy:* A passport or a driver's license. 
  - *Example:* Logging in with a username and password.
- **Authorization (Permissions):** This is the process of verifying **what** a user is allowed to do.
  - *Analogy:* A visa that allows entry but not work, or an "Employees Only" sign.
  - *Example:* An admin can delete records, but a guest can only view them.

## Common Vulnerabilities

| Vulnerability | Description | Prevention Strategy |
| :--- | :--- | :--- |
| **SQL Injection** | Attackers insert malicious SQL commands into input fields to steal or delete data. | Use **Parameterized Queries** or ORMs like Entity Framework. |
| **XSS (Cross-Site Scripting)** | Injecting malicious scripts into web pages that execute in other users' browsers. | **Encode all user input** before displaying it on a page. |
| **CSRF (Cross-Site Request Forgery)** | Tricking a logged-in user into performing an action they didn't intend to do. | Use **Anti-Forgery Tokens** (`ValidateAntiForgeryToken` in .NET). |

## Secure Coding Guidelines

As a trainee, I am committed to following these core principles:
1. **Input Validation:** Always validate data on the server side. Never trust the client.
2. **Parameterized Queries:** Never use string concatenation to build SQL queries.
3. **Always use HTTPS:** Ensure data in transit is encrypted.
4. **Least Privilege:** Users and applications should only have the minimum permissions necessary.

---
*Generated as part of the Wipro Training 2026 program.*
