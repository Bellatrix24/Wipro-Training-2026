# Secure JWT Authentication Web API

A clean ASP.NET Core Web API application developed as a student intern submission for Day 26. The API demonstrates robust JWT token generation and role-based endpoints security.

## Project Purpose

The purpose of this platform is to implement industry-standard cryptographic JSON Web Token (JWT) authentication, force secure HTTPS communication, validate expirations/keys strictly, and secure endpoints based on user claims.

## JWT Authentication Summary

* The platform utilizes `AddJwtBearer` middleware.
* Successfully authenticating at `/api/Auth/login` generates a signed token.
* Tokens are signed with a strong Symmetric Security Key using the HMAC-SHA256 algorithm.
* Middleware enforces verification of Issuer, Audience, Signing Key, and Lifetime Expiry, rejecting expired tokens immediately (with clock skew set to zero).

## Role-Based Authorization Summary

* Enforces role claims (`ClaimTypes.Role`) embedded inside the JWT.
* Utilizes `[Authorize(Roles = "...")]` attributes on controllers to restrict access.
* Includes specialized routes: `/api/Admin/stats` (Admin only), `/api/User/dashboard` (User only), and `/api/Profile/info` (Shared authenticated).

## HTTPS and Security Summary

* Redirection middleware forces TLS/SSL communication by rejecting or redirecting raw HTTP requests.
* Identity lockout rules are configured (5 consecutive failed attempts lock an account for 5 minutes) to protect against active brute-force password guessing.

## How to Run

1. Open a terminal inside the project directory: `SecureJwtAuthApi/SecureJwtAuthApi/`
2. Run command: `dotnet run`
3. Access the interactive Swagger UI API playground by browsing to: `https://localhost:<port>/swagger/index.html`

## Sample Credentials

* **Admin User:** admin@example.com / Password@123 (Possesses 'Admin' role claim)
* **Regular User:** user@example.com / Password@123 (Possesses 'User' role claim)

## API Endpoints List

* `POST /api/Auth/register` - Register a new account
* `POST /api/Auth/login` - Authenticate credentials and get JWT token
* `GET /api/User/dashboard` - Restricted to 'User' role accounts
* `GET /api/Admin/stats` - Restricted to 'Admin' role accounts
* `GET /api/Profile/info` - Shared authenticated endpoint (either role)

## Requirement Checklist

* [x] JWT authentication using ASP.NET Core JwtBearer middleware
* [x] Cryptographic Symmetric Security Key signature verification
* [x] Issuer, Audience, and Lifetime Expiry validations
* [x] Role-Based Access Control claims extraction
* [x] Admin-only, User-only, and Shared protected endpoints
* [x] HTTPS redirection and TLS enforcement
* [x] Brute-force account lockouts and delay mitigation
* [x] SQLite/InMemory Entity Framework Core registrations
* [x] Seed roles and demo accounts seeder
* [x] Database tables SQL script setup
* [x] Swagger UI interactive documentation configured
