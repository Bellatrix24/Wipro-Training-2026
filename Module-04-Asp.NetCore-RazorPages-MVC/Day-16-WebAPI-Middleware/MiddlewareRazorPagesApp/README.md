# ASP.NET Core Assignment: Middleware & Razor Pages

This project represents a professional student submission for Module 04 (ASP.NET Core Razor Pages & MVC) of the Wipro 2026 Training curriculum, specifically focusing on custom pipeline middleware architectures and strongly-typed Razor Page Models.

---

## 📂 Implemented Features

### Part 1: Building a .NET Core Application with Middleware
* **Request & Response Logging**: Implemented in `RequestResponseLoggingMiddleware.cs` using standard ASP.NET logging. It captures and logs the request HTTP method, request path, and the outgoing status code to the server console log.
* **Security Headers CSP**: Implemented in `SecurityHeadersMiddleware.cs` to inject a robust `Content-Security-Policy` header into every single outgoing response, protecting users against malicious cross-site scripting (XSS).
* **Serving Static Files**: Delivers static web files from the `wwwroot` directory. Standard assets are included to verify operation.
* **Custom Error Redirects**: Employs exception handler configurations to redirect unhandled controller or page errors directly to a custom diagnostic page `/Error`.
* **HTTPS Redirection**: Configures secure channel redirection for all HTTP connections.

### Part 2: Implementing Razor Pages with Page Models
* **Catalog Index Page**: Loops through dynamic lists using a C# `@foreach` loop to display current records in clean Bootstrap layouts.
* **Add Item Page**: Features a strongly-bound form mapped using the `[BindProperty]` attribute in the PageModel class code-behind.
* **Trainee Data Entry Validation**: Protects inputs with C# annotations (`[Required]`, `[StringLength]`) and displays intuitive inline error spans on validation failure.
* **Static In-Memory Storage**: Uses a static `ItemStore.cs` list to preserve and append records dynamically across form posts without requiring external databases.

---

## 💻 How to Run the App

Ensure you have the .NET SDK installed (minimum version .NET 8).

### Step 1: Open Terminal
Open a command prompt or PowerShell terminal and navigate to the project directory:
```bash
cd Wipro-Training-2026/Module-04-Asp.NetCore-RazorPages-MVC/Day-16-WebAPI-Middleware/MiddlewareRazorPagesApp
```

### Step 2: Build the Project
Compile the solution to check for issues:
```bash
dotnet build
```

### Step 3: Start the Web Server
Launch the application:
```bash
dotnet run --project MiddlewareRazorPagesApp
```
Take note of the local address listed in the output (typically http://localhost:5000 or similar).

---

## 🎯 Testing and Routes Checklist

### Static Files Routes (served directly from wwwroot)
* **Static HTML Page**: `http://localhost:<port>/index.html` - Static landing page.
* **Static Stylesheet**: `http://localhost:<port>/css/site.css` - Stylesheet for index.html.
* **Static Javascript**: `http://localhost:<port>/js/site.js` - Dynamic load badge confirmation.

### Razor Pages Routes
* **Home Page**: `http://localhost:<port>/` - Introduces this trainee submission.
* **Items Catalog**: `http://localhost:<port>/Items` - Loops over preloaded item entries.
* **Add New Item**: `http://localhost:<port>/Items/Create` - Submit name and description values.
* **Error Page**: `http://localhost:<port>/Error` - Tests custom exception handling layout.

---

## 📋 Git Hygiene & Storage Info
* **Memory-Only Storage**: All item records added during runtime are appended to in-memory static collections only and will reset when the application process terminates.
* **No Build Artifacts**: The parent `.gitignore` file automatically filters build folders (`bin/`, `obj/`) to prevent committing temporary artifacts to GitHub.
