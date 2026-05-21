# Study Notes: Routing Architectures and Session Management

Today's training covered standard networking ports, advanced validations inside ASP.NET Core, the different ways we can route web requests to our controllers, and how to keep track of user sessions across stateless HTTP pages. Here are my daily notes and lab summaries.

---

### Standard Networking Ports

When our web applications communicate across the internet, they use specific standard networking ports to make sure data goes to the right place. Here are the common ones we reviewed:
*   **Port 80 (HTTP)**: Standard unencrypted web traffic.
*   **Port 443 (HTTPS)**: Secure, encrypted web traffic (which is what we use for modern APIs and Razor Pages).
*   **Port 21 (FTP)**: Used for transferring files between computers.
*   **Port 25 (SMTP)**: Standard channel for sending emails.
*   **Port 22 (SSH)**: Secure channel for connecting to servers remotely.

---

### Validation Approaches in ASP.NET Core

To protect our backend systems and build a premium experience, we learned that we can use several validation layers depending on what our form needs:

| Validation Type | What it Does | Why We Use It |
| :--- | :--- | :--- |
| **Data Annotation** | Simple tags (like `[Required]` or `[StringLength]`) written directly inside our C# Model class. | Very easy to set up for basic field constraints. |
| **Client-Side Validation** | Form checks that execute inside the user's browser using JavaScript (like jQuery Validate) before hitting the server. | Gives instant feedback, making the user experience feel extremely smooth and fast. |
| **Server-Side Validation** | Core checks that run securely on our server backend inside the C# logic. | Critical for security! Even if someone bypasses the browser checks, this prevents bad data from ever hitting our database. |
| **Custom Validation** | Writing our own validation logic by inheriting from the standard `ValidationAttribute` class. | Perfect when we have a unique rule, like verifying that a username does not contain restricted symbols. |
| **Model-Level Validation** | Inheriting from the `IValidatableObject` interface inside our Model to write cross-property checks. | Used when one form field depends on another (e.g., verifying that a "Start Date" is earlier than an "End Date"). |
| **Remote Validation** | An asynchronous AJAX check that calls a backend API in the background while the user is still typing. | Great for checking unique database constraints live, like seeing if an email or username is already taken. |

---

### Routing Variations

Routing is the process of mapping a browser's URL path to a specific C# controller action. We practiced three different routing styles in today's lab:

1.  **Conventional / Default Routing**:
    *   *How it works*: Configured globally in `Program.cs`. It defines a fallback structure like `{controller}/{action}/{id?}`.
    *   *Example*: If a user visits `/Home/Index`, the system automatically maps that to the `HomeController` and executes the `Index()` method.
2.  **Custom Named Routing**:
    *   *How it works*: Setting up a specific named route in our startup configurations to map clean, custom URLs to deeply nested folders.
    *   *Example*: Mapping a friendly URL like `/order-food` directly to `/FoodDelivery/Restaurant/ProcessOrder` in the background.
3.  **Attribute Routing**:
    *   *How it works*: Decorating our C# action methods directly with route tags, like `[Route("details/{id:int}")]`.
    *   *Example*: Gives us precise, local control over exactly what URL path maps to a single method, including parameter constraints.

---

### Session Mechanics

As we learned yesterday, HTTP is completely stateless and forgets users immediately after replying to a request. To maintain user login state or shopping cart details, we use a combination of sessions and cookies:
*   **Cookies (Client-Side)**: Small text files saved in the user's browser. They are great for simple preferences (like dark mode), but because the user can modify them, they are not safe for sensitive credentials.
*   **Sessions (Server-Side)**: Sensitive data is saved securely on our server RAM, and the browser is only given a random session ID cookie. The browser presents this ID on every request, letting the server look up their secure session details safely without exposing the actual data to the client!
