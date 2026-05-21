# Study Notes: Razor Pages, Web Templates, and Data Binding

Today we explored how data travels between our HTML web forms and our C# backend. Understanding this data flow (Model Binding) and how ASP.NET Core project templates are structured makes building web pages much easier. Here are my daily notes.

---

### Project Templates in .NET Core

When we start a new web project in .NET Core, we are usually given three main choices of templates:

1.  **Web Application (Razor Pages)**
    *   *What it is*: A page-focused structure. Each web page has its own HTML file (`.cshtml`) and its own C# code-behind file (`.cshtml.cs`). It is really neat and easy to manage for simple websites.
2.  **Web App (Model-View-Controller - MVC)**
    *   *What it is*: A full-stack layered structure. It splits the app into three parts: Models (data), Views (HTML displays), and Controllers (handles the routing and logic). Excellent for large, complex websites.
3.  **Web API**
    *   *What it is*: A backend-only structure. It does not serve HTML pages. Instead, it returns pure, structured JSON data that client-side apps (built in React, Angular, or mobile apps) fetch and show to the user.

---

### Understanding the Razor Pages Lifecycle

Razor Pages run on a simple event-driven lifecycle. The C# backend responds to different HTTP actions sent by the browser:

*   **`OnGet()`**
    *   *How it works*: This method fires automatically when a page first loads up in the user's browser (like typing the URL and hitting enter, or clicking a basic link). It is used to fetch and show initial data.
*   **`OnPost()`**
    *   *How it works*: This method fires automatically when a user submits a form (like clicking a "Submit", "Save", or "Register" button). It is used to capture the data they typed and process it (like saving it to a database).

---

### What is Property Binding?

Model Binding is the magic that connects our HTML form inputs directly to our C# properties without us having to write tedious request-parsing code. We use two main binding decorations:

*   **`[BindProperty(SupportsGet = true)]`**
    *   *Use case*: This binds query strings from the page URL directly to our C# fields. It is perfect for search boxes, search filters, or page numbers where the data is visible in the URL bar.
*   **`[BindProperty]`**
    *   *Use case*: This binds data sent inside standard HTML form posts. The data travels securely inside the HTTP request body instead of the URL, which is the standard way to submit login fields or registration forms.

---

### The Benefit of Layered Architectures (like MVC)

Separating our codebase into distinct layers (like Model-View-Controller) is incredibly useful:

*   **Decoupled UI**: By keeping our HTML views completely separate from our core C# data schemas and business rules, we ensure that changing a website's layout (CSS/HTML) won't break our core database logic.
*   **Easier Testing**: We can write tests for our business logic layer independently without needing to spin up a browser or a web server interface.

---

### Why Validation is Important

Before we save any data that a user typed into a web form, we must validate it to ensure it is correct and safe:

*   **Client-Side Validation**: Happens inside the browser using JavaScript. It is super fast and gives instant feedback if a user forgets to fill a required field or enters a bad email format.
*   **Server-Side Validation**: Happens securely on our C# backend. Even if a bad actor bypasses the browser validations, our secure backend double-checks the data to make sure no corrupt or dangerous inputs can ever reach our database models.
