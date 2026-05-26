# Secure Task Management Platform

A secure ASP.NET Core MVC application developed as a student intern submission for Day 25. The platform allows users to manage tasks and submit comments, focusing heavily on modern web security practices.

## Project Purpose

The purpose of this platform is to demonstrate robust security implementation in ASP.NET Core MVC, handling data securely, enforcing roles/claims, and mitigating common OWASP vulnerabilities.

## Security Features Implemented

* **Secure Forms Authentication:** Leverages ASP.NET Core Identity with strong salted/hashed passwords.
* **Role and Claims-Based Authorization:** Restricts tasks dashboard to regular users and general management to administrators. Features a claims-based policy (`CanEditTask`) to verify users permitted to update task details.
* **Anti-Forgery (CSRF) Protection:** Enforces `[ValidateAntiForgeryToken]` and uses tag helpers on all submission forms.
* **XSS Prevention:** Explicitly sanitizes all incoming titles, descriptions, and comments using HTML encoding. Utilizes default Razor encoding on views.
* **Secure Session Management:** Configures strict HTTPS-only, HttpOnly, and Strict SameSite cookie behaviors. Configures a 15-minute inactivity session idle timeout.
* **Secure Sign Out:** Clears the cookie container, invalidates session storage, and performs redirect routing upon logout.
* **Brute-Force Mitigation:** Implements accounts lockout rules (locked for 5 minutes after 5 consecutive failures) combined with active delays.

## Demo Credentials

* **Administrator:** admin@example.com / Password@123 (Full privileges + CanEditTask claim)
* **Regular User:** user@example.com / Password@123 (Regular taskboard + CanEditTask claim)
* **Limited User:** limited@example.com / Password@123 (Regular taskboard but no CanEditTask claim - fails claims check)

## How to Run

1. Open a terminal inside the project directory: `SecureTaskManagementPlatform/SecureTaskManagementPlatform/`
2. Run command: `dotnet run`
3. Access the web interface through the URL logged in the terminal (usually HTTPS port).

## Requirement Checklist

* [x] Forms-based registration and login
* [x] Automatic password hashing and salting
* [x] Role-based routing for Admin and User
* [x] Claims-based policy: CanEditTask
* [x] Anti-forgery tokens (CSRF) on all POST forms
* [x] Text input validation and XSS HTML sanitization
* [x] HttpOnly, Secure, SameSite Strict cookies
* [x] 15 minutes inactivity session timeout
* [x] Secure sign out session invalidation
* [x] Seed user and roles data seeder
* [x] SQL database setup script
