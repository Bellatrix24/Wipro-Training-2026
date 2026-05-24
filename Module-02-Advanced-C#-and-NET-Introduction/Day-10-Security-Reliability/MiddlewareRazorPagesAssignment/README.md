# Middleware and Razor Pages Web Application (Day 10)

Welcome to the Day 10 combined Wipro training assignment! This project implements a secure and robust **ASP.NET Core Razor Pages** application demonstrating custom middleware processing, Content Security Policy header protection, static files service, and dynamic data binding using in-memory model stores.

---

## Objective

The objective of this assignment is to understand the two core pillars of ASP.NET Core web development:
1. **Middleware Pipeline**: How HTTP requests flow through sequential modules (logging, security headers, exception handling, static file servers, and routing).
2. **Razor Pages Model View Controller**: How PageModels isolate backend data-binding and logic (`PageModel` handlers, property bindings, validation, and view composition).

---

## What Assignment 1 Implements: Middleware + Static Files

1. **Request/Response Logging**:
   A custom inline middleware captures every incoming HTTP request method and path, processes it through the pipeline, and logs the outgoing HTTP response status code to the terminal.
2. **Content Security Policy (CSP)**:
   A custom middleware injects the security header:
   `Content-Security-Policy: default-src 'self'; script-src 'self'; style-src 'self';`
   *This restricts scripts, styles, and other assets to load only from local local origins, reducing the risk of Cross-Site Scripting (XSS) injection.*
3. **HTTPS Redirection & Error Handling**:
   Enforces secure HTTPS transport via redirection, and maps all application exception errors gracefully to a friendly `/Error` landing page while hiding debug stack traces.
4. **Static File Server**:
   Enables the serving of static html and assets placed in `wwwroot/` via `app.UseStaticFiles()`.

---

## What Assignment 2 Implements: Razor Pages + In-Memory Catalog

A lightweight item list/catalog system comprising:
1. **Domain Model (`Item.cs`)**: Represents catalog items with properties `Id` (int), `Name` (string), and `Description` (string).
2. **In-Memory Service (`ItemStore.cs`)**: Stores items using a thread-safe static collection. Pre-seeded with 3 sample items. Supports retrieving all items and contributing new items safely.
3. **Dynamic Razor Views**:
   - **`/Index` (Home Page)**: Renders a premium glassmorphic layout introducing the assignment architecture.
   - **`/Items` (Catalog Page)**: Queries `ItemStore` and renders items dynamically in an elegant table using an inline Razor `@foreach` loop.
   - **`/AddItem` (Creation Page)**: Renders a contribution form. Integrates input field validation rules. Uses `[BindProperty]` for C# model state validation and redirects to `/Items` on successful POST.
   - **`/Error` (Diagnostic Page)**: Gracefully landing for errors, showing standard reference codes without exposing stack traces.

---

## Folder Structure

Below is the directory layout of this assignment:

```text
MiddlewareRazorPagesAssignment/
├── MiddlewareRazorPagesAssignment.sln  # Solution file
├── README.md                           # This documentation file
│
└── MiddlewareRazorPagesApp/            # ASP.NET Core Razor Pages Project
    ├── Program.cs                      # Minimal hosting, Services & Middleware setup
    ├── MiddlewareRazorPagesApp.csproj  # Web Project configuration
    │
    ├── Models/
    │   └── Item.cs                     # Item domain model
    │
    ├── Services/
    │   └── ItemStore.cs                # In-memory thread-safe data store
    │
    ├── Pages/                          # Razor Pages views and PageModels
    │   ├── _ViewImports.cshtml         # Tag helpers imports
    │   ├── _ViewStart.cshtml           # Theme layout definitions
    │   ├── Index.cshtml / .cshtml.cs   # Welcome landing page
    │   ├── Items.cshtml / .cshtml.cs   # Dynamic table listing
    │   ├── AddItem.cshtml / .cshtml.cs # Secure form post + validation
    │   ├── Error.cshtml / .cshtml.cs   # Graceful diagnostic page
    │   └── Shared/
    │       └── _Layout.cshtml          # Shared master layout system
    │
    └── wwwroot/                        # Static Content Served directly
        ├── index.html                  # Stand-alone static page link
        ├── css/
        │   └── site.css                # Style sheet
        └── js/
            └── site.js                 # Local script
```

---

## How Middleware Works in This Project

In ASP.NET Core, the HTTP request pipeline is composed of sequential modules called **Middleware**. In this application, minimal hosting style in `Program.cs` is used:

```csharp
// 1. Logging Middleware: Logs incoming request and outgoing response status
app.Use(async (context, next) => {
    Console.WriteLine($"[LOG] Incoming Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"[LOG] Outgoing Response: {context.Response.StatusCode} for {context.Request.Path}");
});

// 2. CSP Middleware: Injects XSS-mitigating security headers
app.Use(async (context, next) => {
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; script-src 'self'; style-src 'self';";
    await next();
});

// 3. Exception Handler Middleware
app.UseExceptionHandler("/Error");

// 4. HTTPS Redirection
app.UseHttpsRedirection();

// 5. Static Files Server
app.UseStaticFiles();
```

---

## How to Run the Project

Ensure you have the .NET SDK installed. To boot the application:

1. Restore the packages:
   ```bash
   dotnet restore
   ```
2. Build the project:
   ```bash
   dotnet build
   ```
3. Run the web server:
   ```bash
   dotnet run --project MiddlewareRazorPagesApp
   ```

---

## URLs to Test

When the server runs, open your browser and navigate to:
- **Home Landing Page**: `http://localhost:5000/` or `https://localhost:5001/` (or the specific port printed in the terminal).
- **Dynamic Catalog**: `https://localhost:5001/Items`
- **Contribution Form**: `https://localhost:5001/AddItem`
- **Static Landing Page**: `https://localhost:5001/index.html`

---

## How to Verify Features

1. **Verify Request/Response Logging**:
   Observe your IDE/terminal window when accessing pages. You will see logs printing method, path, and outgoing status code:
   ```text
   [LOG] Incoming Request: GET /Items
   [LOG] Outgoing Response: 200 for /Items
   ```
2. **Verify Static File Serving & CSP**:
   Navigate to `/index.html`. Click the "Run Static Script Test" button. A browser alert will notify you that the script loaded successfully under local CSP rules. Inspect the headers in the browser Network tab to verify that `Content-Security-Policy` is appended.
3. **Verify Dynamic Contributions**:
   Open `/AddItem`. Try submitting empty fields to check client/server validation. Then submit a valid Name and Description. You will be redirected back to `/Items` where your newly added item will immediately appear in the table.
