# Day 9: .NET Core CLI and Web Scenarios

## Overview
Today's session was very exciting! I moved beyond basic C# scripts and started exploring how to build real-world applications using the **.NET Core CLI (Command Line Interface)**. Instead of relying solely on the Visual Studio UI, I learned how to scaffold projects quickly using terminal commands.

## Scenarios Practiced
I practiced creating three different types of projects to understand the variety of applications we can build with .NET:

1.  **Console App (Task List Manager):** A simple text-based application to manage daily chores.
2.  **MVC App (E-commerce Product Catalog):** A Model-View-Controller setup for a web-based product listing.
3.  **Web API (User Registration Microservice):** A backend service for handling user sign-ups via RESTful endpoints.

## Synchronous vs. Asynchronous Execution
Based on the performance demo I saw earlier, here is my takeaway:

*   **Synchronous (Sync):** Tasks are performed one after another. If one task takes a long time (like a heavy database query), the whole program "freezes" and waits for it to finish.
*   **Asynchronous (Async):** Tasks can run in the background. The program doesn't wait; it moves on to other things and comes back when the background task is done. This makes web apps feel much smoother and more responsive!

---
*Created as part of my .NET Training journey.*
