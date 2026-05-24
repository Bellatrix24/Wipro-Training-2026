# ASP.NET Core MVC Filters Application

This repository contains a clean, single-solution ASP.NET Core MVC application developed as a training submission. It demonstrates the implementation and utilization of custom MVC filters (Action, Authorization, and Exception filters) across e-commerce checkout and online banking contexts using in-memory data structures.

## Project Purpose

The purpose of this application is to showcase how custom filters can intercept the MVC request execution pipeline:
1. E-Commerce Platform with Advanced MVC Filters: Implementing request URL/method logging, conditional page redirection for authentication, and global exception filtering.
2. Online Banking Application with Advanced MVC Filters: Enforcing role-based authorization for administrative consoles, logging critical user actions (such as funds transfer), and capturing banking runtime exceptions.

## Features Implemented

* Custom Action and Authorization Filters:
  * RequestLoggingFilter: Logs request URL, method, and response status code to an in-memory service registry globally.
  * SimpleAuthenticationFilter: Validates if a user session is logged in (represented via query strings) and redirects guests to Account/Login.
  * RoleAuthorizationFilter: Restricts access to administrative endpoints (like /Admin/Users) strictly to user sessions verified with the admin role.
  * UserActionLoggingFilter: Tracks and logs customer operations (such as performing funds transfers) including user ID, action performed, and timestamp.
  * GlobalExceptionFilter: Catches all unhandled exceptions globally, registers details in the exception log, and renders a user-friendly error dashboard.
* Simulated In-Memory Services:
  * LoggingService: Persists request, user action, and exception logs in static memory.
  * AuthService: Manages mock login states and current session username checks.
  * UserRoleService: Evaluates role mappings dynamically.
* Core E-Commerce & Banking Views:
  * Products: Public list of products with a Filters Test Suite sidebar.
  * Orders: Checkout view protected by authentication filters.
  * Account: Standard simulated login page containing session triggers.
  * Banking: Accounts balance listing, ledger transactions history, and simulated wire transfer form.
  * Admin: User registry listing restricted exclusively to the admin role.
  * Shared Error: Custom friendly exception handler page.
* Automated Unit Testing: Includes a complete xUnit project validating standard filter activities, logging behaviors, redirection, and authorization constraints.

## How to Run

1. Navigate to the project directory:
   ```bash
   cd MvcFiltersBankingStoreApp
   ```
2. Build the solution:
   ```bash
   dotnet build
   ```
3. Run the automated unit tests:
   ```bash
   dotnet test
   ```
4. Run the web application:
   ```bash
   dotnet run --project MvcFiltersBankingStoreApp
   ```
5. Open your browser and navigate to http://localhost:5000 (or the port specified by the dotnet output).

## Routes to Test

A Logging Console is attached to the bottom of the master layout to show filters firing in real-time as you click each path:
* `/Products`: Public products listing. Starts the RequestLoggingFilter.
* `/Orders/Checkout?loggedIn=true`: Bypasses the authentication check and loads the secure checkout screen.
* `/Orders/Checkout?loggedIn=false`: Fails the authentication check, triggering a redirect to the Account/Login screen.
* `/Banking/Accounts?loggedIn=true`: Displays John's active savings and checking balances.
* `/Banking/Transactions?loggedIn=true`: Lists past transactions and wire logs.
* `/Banking/Transfer?loggedIn=true`: Simulator form allowing in-memory transfers. Submitting a transfer triggers the UserActionLoggingFilter.
* `/Admin/Users?loggedIn=true&role=admin`: Accesses the admin console via successful role authorization.
* `/Admin/Users?loggedIn=true&role=user`: Fails the authorization filter check, returning an Access Denied 403 response.
* `/ErrorDemo/Throw`: Throws an unhandled runtime error to verify that the GlobalExceptionFilter intercepts it gracefully.

## Requirement Checklist

* Created controllers for Products, Orders, Account, Banking, Admin, and Error Demo.
* Implemented five custom filters: RequestLoggingFilter, SimpleAuthenticationFilter, RoleAuthorizationFilter, UserActionLoggingFilter, and GlobalExceptionFilter.
* Registered dependencies in Program.cs and applied filters globally and via TypeFilter injection.
* Added standard Bootstrap views for catalog, checkout, login, banking, admin, and friendly errors.
* Included xUnit test project asserting correct filter behaviors.
* Cleaned all bin/obj files, ensured clean build, and verified that no emojis or em-dashes are used.
