# Security Review Checklist

A simple defensive review checklist for secure coding and database access.

## Database & Query Security
- [x] Query Parameterization: All SQL statements use EF Core parameterized queries; no raw string concatenations are permitted.
- [x] Passwords Protection: Hashed securely using Identity PBKDF2 with SHA256 iterations. No plain text storage.
- [x] Encryption-at-Rest: Cryptographically sensitive fields (e.g. TaxId) are AES-encrypted before insert.
- [x] Integrity Signatures: Dynamic SHA256 HMAC validations check for tampering on load.

## Session & Cookie Safety
- [x] HttpOnly Flag: Configured true on all cookies to prevent script access.
- [x] Secure Flag: Cookie secure policy forces SSL/TLS HTTPS delivery.
- [x] Session Timeout: Idle expiry is set strictly to 15 minutes of inactivity.
- [x] Session Invalidation: HttpContext session cleared and auth cookies deleted explicitly upon logout.

## Front-End Mitigations
- [x] Cross-Site Scripting (XSS): Inputs validated via Model State and outputs automatically encoded using Razor engine blocks.
- [x] Cross-Site Request Forgery (CSRF): Explicit `[ValidateAntiForgeryToken]` annotations protect all POST actions.
- [x] Input Sanitization: Explicit trim and strip utilities operate on all user text inputs.

## Access Control & Least Privilege
- [x] Role-Based Access Control (RBAC): Admin and User claims distinguish access to stats and logs.
- [x] Connection String Protection: Stored in secure config parameters rather than hardcoded credentials.
