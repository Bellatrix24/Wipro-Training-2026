# Online Bookstore Application

This repository contains a clean, hybrid ASP.NET Core web application developed as a training submission. It integrates both MVC Controllers/Views and Razor Pages to build a complete bookstore platform featuring in-memory repositories, session-based cart management, custom model validations, and security interceptor filters.

## Project Purpose

The purpose of this project is to demonstrate the building of a full hybrid ASP.NET Core web application under Day 20 training guidelines:
* MVC Pattern: Leveraged for the user-facing storefront views (listing all books, viewing detailed descriptions) and the transactional checkout views (order summary, confirmation receipt).
* Razor Pages: Utilized for book inventory management (Add, Edit, Delete actions), shopping cart adjustments, and user identity registration/login forms.
* Advanced Pipeline Control: Applied custom authorization, authentication, logging, and error handling filters across the unified application context.

## Main Features

* Hybrid Framework Architecture: Combines MVC (for public actions and receipts) and Razor Pages (for form-driven inventory CRUD and stateful carts) in a single solution.
* Mock Authentication & Role Security:
  * Uses simple in-memory session variables (Username and Role) to track active login state.
  * AuthFilter: Secures checkout and order placement actions, redirecting guest sessions to the Razor Page login screen.
  * RoleFilter: Restricts book inventory modifications (Add, Edit, Delete pages) strictly to users authenticated with the Admin role.
* Shopping Cart & Orders:
  * Persistent Shopping Cart: Stored inside session state using custom JSON serialization extensions, allowing items to persist across requests.
  * Summary & Checkout: MVC orders workflow saving invoice details to an in-memory repository and returning a printable invoice confirmation page.
* Custom Validations & Pipeline Filters:
  * IsbnValidationAttribute: Ensures book ISBN numbers adhere strictly to a valid 13-digit format.
  * PriceRangeAttribute: Validates that book prices are restricted within the range of $1.00 to $500.00.
  * LoggingFilter: Intercepts action calls to log HTTP methods and paths to standard diagnostics.
  * GlobalExceptionFilter: Catches all unhandled exceptions, logs the trace, and displays a friendly error page.

## How to Run

1. Navigate to the project directory:
   ```bash
   cd OnlineBookstoreApp
   ```
2. Build the solution to verify code health:
   ```bash
   dotnet build
   ```
3. Run the bookstore application:
   ```bash
   dotnet run --project OnlineBookstoreApp
   ```
4. Open your browser and navigate to the local hosting address (e.g., http://localhost:5000 or as indicated by the console output).

## Routes to Test

All routes use standard ASP.NET Core conventions combined with custom mappings:
* `/Books`: Catalog main page (MVC list).
* `/Books/Details/{id:int}`: Display description (throws custom error if book ID is invalid to test the Exception filter).
* `/Cart`: Review current cart items (Razor Page).
* `/Cart/Add/{id:int}`: Adds selected book to session cart (Razor Page handler).
* `/Cart/Remove/{id:int}`: Removes book from session cart (Razor Page handler).
* `/Inventory/Add`: Add a new book (Razor Page - restricted to Admin role).
* `/Inventory/Edit/{id:int}`: Edit book metadata (Razor Page - restricted to Admin role).
* `/Inventory/Delete/{id:int}`: Remove book item (Razor Page - restricted to Admin role).
* `/Account/Register`: User sign-up (Razor Page).
* `/Account/Login`: User sign-in (Razor Page).
* `/Account/Logout`: Clears current session data (Razor Page).
* `/Orders/Summary`: Checkout confirmation screen (MVC - restricted to authenticated users).
* `/Orders/Confirmation/{id:int}`: Final invoice receipt page (MVC - restricted to authenticated users).

## Demo User Accounts

Use the following credentials to authenticate sessions and verify role authorization filters:
* **Admin Role (Can manage inventory CRUD)**:
  * Username: `admin`
  * Password: `admin123`
* **Customer Role (Can browse, add to cart, and checkout)**:
  * Username: `customer`
  * Password: `customer123`

## Requirement Checklist

* Created unified project structure covering Controllers, Models, Filters, Pages, Repositories, Validations, and Views.
* Programmed hybrid routing architecture mapping both controllers and razor pages convention models.
* Registered custom validation attributes `IsbnValidation` and `PriceRange` on Book models.
* Secured inventory pages under `RoleFilter` and orders summary under `AuthFilter`.
* Built persistent session cart serialization using JSON extensions.
* Created friendly shared MVC Error.cshtml view showing custom exceptions.
* Maintained clean code hygiene: Compiled with zero warnings/errors, deleted bin/obj folders, and excluded emojis and em-dashes.
