# Secure Shopping Platform

This is a simple ASP.NET Core MVC project for the Day 25 assignment. It uses ASP.NET Core Identity for login, registration, logout, roles, and password hashing.

## Features

- User registration and login
- Secure logout
- Admin and Customer roles
- Product listing
- Customer purchase flow
- Customer order history
- Admin dashboard at `/Admin/Dashboard`
- EF Core models for users, products, orders, and order items

## Security used

- ASP.NET Core Identity hashes and salts passwords
- Strong password rule: 8 characters, uppercase, number, and special character
- Email validation on registration and login
- Role based authorization
- EF Core queries only, no dynamic SQL
- Razor output encoding
- Anti-forgery tokens on forms
- Simple login delay after repeated failed attempts

## Seed users

The app creates these users when it starts:

| Email | Password | Role |
|---|---|---|
| admin@example.com | Password@123 | Admin |
| customer@example.com | Password@123 | Customer |

## Run

```bash
cd SecureShoppingPlatform
dotnet run
```

The app uses an InMemory database by default. The migration and SQL script are included for reference if SQL Server is used later.
