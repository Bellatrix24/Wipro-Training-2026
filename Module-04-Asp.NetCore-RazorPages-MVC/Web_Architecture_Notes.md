# Study Guide: Web Development Basics and Web Architecture

Today we started exploring how the web works and how Microsoft's tools fit into it. Web development seems a bit different from writing basic console programs, but once you break it down into pieces, it actually makes a lot of sense! Here are my study notes for the day.

---

### Understanding the Client vs. Server Model

When we open a website, there are two main sides working together to show us the page: the **Client** (our web browser) and the **Server** (a powerful computer running somewhere else).

Here is a quick comparison table to help me remember who does what:

| Feature | Client-Side | Server-Side |
| :--- | :--- | :--- |
| **Where it runs** | Runs directly inside the user's web browser (like Chrome, Edge, or Safari). | Runs on a remote computer or cloud server. |
| **Technologies used** | HTML (for structure), CSS (for design), and JavaScript (for interactive buttons/forms). | C# (using ASP.NET Core), SQL databases, and file systems. |
| **Main job** | Shows the user interface, makes animations run, and handles basic user input validations. | Performs secure business logic, queries database tables, and processes user logins securely. |
| **Security context** | Not secure for private code because anyone can inspect the code in the browser. | Highly secure since users cannot see the backend C# code or database credentials. |

---

### How Microsoft Web Technology Evolved

Microsoft has had a few different web frameworks over the years. Understanding the history helps make sense of why ASP.NET Core is built the way it is today:

1.  **Classic ASP (Active Server Pages)**
    *   *The start*: Back in the late 1990s, developers mixed raw VBScript and HTML together in the same file. It worked, but it got very messy and hard to manage as sites grew.
2.  **ASP.NET Web Forms**
    *   *The drag-and-drop era*: Released in the early 2000s, this tried to make web development feel like drag-and-drop desktop development. It was easy for beginners but generated heavy web pages and was hard to customize.
3.  **ASP.NET MVC (Model-View-Controller)**
    *   *Separation of logic*: Split the code into three parts: Models (data), Views (HTML structure), and Controllers (business logic). This made code much cleaner and easier to test.
4.  **Modern ASP.NET Core**
    *   *Where we are now*: A complete rewrite that is super fast, light, and cross-platform (meaning it runs perfectly on Windows, macOS, and Linux). This is what we are learning and using today!

---

### Application Style Comparison

Depending on what we are building, we use different styles of applications:

*   **Console Applications**
    *   *Style*: Simple terminal or command-prompt based tools.
    *   *Scope*: Great for learning basic programming syntax, writing quick scripts, or building background automation tools. There is no graphical user interface (GUI).
*   **Desktop Applications**
    *   *Style*: Graphical programs that run locally on a single machine (like Windows Forms or WPF).
    *   *Scope*: Excellent for high-performance software that needs direct access to the local machine's hardware or works completely offline.
*   **Web Applications**
    *   *Style*: Programs accessed through a web browser over the internet (like ASP.NET Core MVC or Razor Pages).
    *   *Scope*: Best for reaching a massive audience because users don't have to install anything locally—they just navigate to a URL.
