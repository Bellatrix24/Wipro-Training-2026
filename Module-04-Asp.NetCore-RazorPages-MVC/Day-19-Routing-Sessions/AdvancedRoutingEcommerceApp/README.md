# Advanced Routing E-Commerce Application

This project is a clean, single-solution ASP.NET Core MVC application developed as a training submission. It covers advanced routing concepts, custom route constraints, dynamic dashboard rendering based on query values, and simulated user session states for e-commerce checkout operations using in-memory data structures.

## Project Purpose

The purpose of this application is to demonstrate ASP.NET Core routing capabilities by resolving two core assignments:
1. Advanced Routing in an MVC Application: Configuring complex routes, registering and applying custom route constraints (such as GUID verification), and managing dynamic rendering using controller action parameters.
2. E-Commerce Application with Advanced Routing: Implementing category and price range matching filters, handling logged-in user checkouts versus guest redirects, and unit testing all route constraint logic.

## Features Implemented

* Custom Route Constraints:
  * GuidRouteConstraint: Ensures that target parameters represent a valid GUID.
  * CategoryRouteConstraint: Restricts product categories strictly to case-insensitive values: electronics or books.
  * PriceRangeRouteConstraint: Parses and verifies price ranges formatted as minPrice-maxPrice (for example: 100-500) where values are positive decimals and minPrice is less than or equal to maxPrice.
* Advanced MVC Routes:
  * Product Browsing: `/Products/{category}/{id}`
  * Custom Products Filtering: `/Products/Filter/{category}/{priceRange}`
  * User Order History: `/Users/{username}/Orders`
  * Dynamic Role Dashboards: `/Dashboard?role=admin` and `/Dashboard?role=user`
  * Conditional Guest Checkout: `/Checkout?loggedIn=true` or `/Checkout?loggedIn=false`
  * GUID Page Details: `/GuidDemo/{guid}`
* Dynamic Dashboard Rendering: Loads unique dashboard layouts depending on the active query parameter role (Admin Dashboard vs Regular User Portal).
* Authentication Routing: Dynamically redirects guest users visiting `/Checkout` to a simulated login page, allowing them to sign in and proceed securely.
* High-Fidelity UI System: Developed custom styling in site.css featuring a modern dark-mode layout with responsive grids, interactive route testing panels, hover micro-animations, and glassmorphic card aesthetics.
* Automated Unit Testing: Includes a complete xUnit test project asserting that custom route constraints validate correctly under various success and failure test conditions.

## How to Run

1. Open a terminal and navigate to the project directory:
   ```bash
   cd AdvancedRoutingEcommerceApp
   ```
2. Build the solution to restore packages and verify compilation:
   ```bash
   dotnet build
   ```
3. Run the automated xUnit tests to verify route constraints:
   ```bash
   dotnet test
   ```
4. Run the web application locally:
   ```bash
   dotnet run --project AdvancedRoutingEcommerceApp
   ```
5. Open your browser and navigate to the local hosting port (usually http://localhost:5000 or as indicated by the dotnet output).

## Routes to Test

An interactive route-testing panel is embedded directly in the homepage sidebar. You can test each path with a single click:
* `/`: Home catalog landing page.
* `/Products/electronics/1`: Product details page for Developer Laptop.
* `/Products/books/5`: Product details page for Clean Coding Patterns.
* `/Products/Filter/electronics/100-500`: Returns electronics within the 100 to 500 price range.
* `/Products/Filter/books/10-50`: Returns books within the 10 to 50 price range.
* `/Users/john/Orders`: Lists order history for user john.
* `/Dashboard?role=admin`: Renders the Admin Console.
* `/Dashboard?role=user`: Renders the Customer Portal.
* `/Checkout?loggedIn=false`: Simulates a guest checkout, triggering a redirect to the login screen.
* `/Checkout?loggedIn=true`: Simulates a logged-in checkout, loading the secure purchase page.
* `/GuidDemo/[valid-guid]`: Validates and displays a successfully matched GUID segment.

## Requirement Checklist

* Created complex MVC route patterns for products and order history.
* Registered GuidRouteConstraint, CategoryRouteConstraint, and PriceRangeRouteConstraint.
* Implemented dynamic dashboard views based on query parameters.
* Configured advanced routes in Program.cs.
* Set up redirection logic on Checkout to send guests to the Login page.
* Created interactive Views with premium dark-mode styling and glassmorphism.
* Added an xUnit test project verifying all constraint conditions (18 test scenarios passed).
* Maintained clean repository hygiene, ensuring no emojis, no em-dashes, and clean compilation.
