# Secure Database Security Portal

A basic ASP.NET Core MVC application built for the Day 26 assignment. It shows simple ways to secure a database, protect sensitive fields with encryption, check data integrity with HMACs, and log access attempts.

## Project Purpose

The purpose of this project is to demonstrate basic database security practices:
* Preventing SQL injection using standard EF Core parameterized queries.
* Encrypting sensitive data (like Tax IDs) using AES encryption before saving.
* Checking if data has been modified in the database using a simple SHA256 HMAC.
* Keeping a simple audit log of standard actions and suspicious attempts.

## Database Security Setup

* **No SQL Injection:** Uses standard Entity Framework Core queries which automatically parameterize inputs.
* **Credential Protection:** Uses ASP.NET Core Identity with PBKDF2 hashing for secure passwords.
* **Data Encryption:** Encrypts Tax IDs using a simple AES service.
* **Integrity Checking:** Generates an HMAC of the data when saving, and compares it upon loading. If they do not match, the system flags the record as tampered.

## Secure Coding Practices

* **CSRF Protection:** Uses standard ASP.NET Core ValidateAntiForgeryToken tokens on POST forms.
* **XSS Prevention:** Relies on Razor view engine automatic HTML encoding and basic model validation.
* **Audit Trail:** A simple database table that logs login attempts, lockouts, and tampering detections.

## Authentication and Roles

* **Role-Based Access Control:** Defines Admin and User roles.
* **Access Restrictions:** 
  * Only users in the Admin role can access the audit logs (/Audit/Logs) and admin management (/Admin/ManageData).
  * Registered users can view the decrypted records (/Profile/SecureRecords).
* **Session Management:** Set to 15 minutes idle timeout with HttpOnly and Strict SameSite options.

## How to Run

1. Navigate to the MVC folder: `SecureDatabaseSecurityPortal/SecureDatabaseSecurityPortal/`
2. Run the project: `dotnet run`
3. Open the browser and visit the local HTTPS URL shown in the console.

## Seeded Users for Testing

* **Admin User:** admin@example.com / Password@123 (Has access to audit logs and admin tools)
* **Standard User:** user@example.com / Password@123 (Can view decrypted customer records)
