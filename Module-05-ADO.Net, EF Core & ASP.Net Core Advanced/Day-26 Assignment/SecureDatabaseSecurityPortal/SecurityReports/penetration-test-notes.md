# Penetration Test Notes

Defensive assessment notes identifying security vulnerabilities mitigated in the SecureDatabaseSecurityPortal.

## 1. SQL Injection (SQLi)
* **Risk:** Attacker inputs malicious queries to leak database records.
* **Mitigation:** The application uses Entity Framework Core for all database interactions. EF Core automatically generates parameterized SQL statements, treating input parameters as literal values rather than executable code. No dynamic raw SQL string concatenations are used.

## 2. Stored & Reflected Cross-Site Scripting (XSS)
* **Risk:** Attacker injects `<script>` tags to hijack user cookies and sessions.
* **Mitigation:** All inputs are strictly validated through ViewModels. Any user-generated string is automatically HTML-encoded by the Razor rendering engine before being displayed in browser contexts. Highly sensitive text input fields are also sanitized.

## 3. Cross-Site Request Forgery (CSRF)
* **Risk:** Third-party sites issue unauthorized post requests on behalf of authenticated users.
* **Mitigation:** ASP.NET Core anti-forgery tag helpers append secure hidden validation tokens (`__RequestVerificationToken`) to every MVC form, and corresponding controllers enforce matching token validations using the `[ValidateAntiForgeryToken]` attribute.

## 4. Cryptographic Integrity Validation
* **Risk:** Malicious DB admin alters table records directly.
* **Mitigation:** When records are retrieved, HmacService calculates the SHA256 HMAC of the decrypted value and compares it to the stored signature. Any manual alteration triggers database-tampering alerts in the audit trail, immediately blocking compromised data from display.
