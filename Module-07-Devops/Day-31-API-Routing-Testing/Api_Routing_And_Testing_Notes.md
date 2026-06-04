# Day 31: API Routing Mechanics and Endpoint Verification Tools

Today's training was all about routing—the system that guides HTTP requests from the outside world to the right place in our code—and the tools we use to verify everything is working before we hand it over to the frontend team.

---

## 1. Why Routing is the Backend Traffic Manager

Routing is basically the GPS of our web application. When a frontend app or mobile client sends an HTTP request (like a GET or POST), it hits our server as a URL string (e.g., `GET /api/products/42`). 

*   **The Problem:** The server doesn't automatically know what C# class or method should run just by looking at a string.
*   **The Solution:** The routing engine acts as a central traffic controller. It inspects the incoming URL string and maps it directly to the exact controller class and action method meant to handle it.
*   **Student Reminder:** Without routing maps, the backend is just a black box. Frontend clients would have no way to request data, update records, or talk to our databases.

---

## 2. Conventional vs. Attribute Routing

In ASP.NET Core, we studied two different ways to configure these routing paths:

### Conventional Routing
*   **What it is:** A broad, pattern-based approach where we define global templates in `Program.cs`.
*   **Example Template:** `app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");`
*   **How it works:** The engine looks at the URL (like `/Product/Detail/101`) and breaks it down by parts: Controller = `ProductController`, Action = `Detail`, ID = `101`.
*   **Best for:** Traditional MVC applications where we serve HTML views.

### Attribute Routing
*   **What it is:** A direct, granular approach where we map paths directly onto individual classes and methods using C# attributes (decorator tags).
*   **Example Tag:** `[Route("api/[controller]")]` at the class level, and `[HttpGet("{id}")]` on the method.
*   **How it works:** The URL is defined right next to the code that handles it. There's no guessing about which template it matches.
*   **Best for:** RESTful APIs (which return JSON or XML instead of HTML views). It gives us total control over the URL structure.

---

## 3. API Verification and Debugging Tools

We can't just build APIs and hope they work. We need ways to send test requests and intercept network traffic. Here are the two primary tools we learned to use today:

### Postman
*   **What it is:** A GUI client tool for creating and sending manual HTTP requests (GET, POST, PUT, DELETE, etc.).
*   **Why we use it:** 
    *   It lets us test our API endpoints isolated from any frontend code.
    *   We can customize headers, add JSON payloads in the request body, and verify status codes (like `200 OK`, `400 Bad Request`, `401 Unauthorized`).
    *   We use it to double-check that our JWT security authorization works and that our JSON response structures look correct before we tell the UI developers that the API is ready.

### Fiddler Proxy
*   **What it is:** A low-level web proxy tool that sits between our computer and the internet, intercepting live HTTP and HTTPS packet data.
*   **Why we use it:**
    *   Unlike Postman (which is just a sender), Fiddler is a listener. It records *all* outgoing and incoming network packets on the machine.
    *   We use it to inspect the raw headers, examine authentication cookies, and debug production redirect loops or HTTPS handshake issues. It is perfect for seeing exactly what is happening over the wire.
