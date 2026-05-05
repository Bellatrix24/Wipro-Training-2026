# Day 8: Reflection, Generics, and Functional C# for Web

## Learning Summary
Today marks a significant transition in our training. We moved from deep-diving into **advanced backend logic** (like searching algorithms and file handling) towards **Web Projects** using **ASP.NET Core**. We explored how C# becomes more functional and flexible using Reflection and Generics, and how these concepts lay the foundation for modern web architecture.

---

## Anonymous Methods vs. Lambda Expressions
In C#, we can write inline code without defining a separate function. Here is the comparison:

| Feature | Anonymous Methods | Lambda Expressions |
| :--- | :--- | :--- |
| **Syntax** | Uses the `delegate` keyword. | Uses the `=>` (arrow) operator. |
| **Conciseness** | More verbose. | Very concise and readable. |
| **Usage** | Older style (C# 2.0). | Modern style (C# 3.0+), preferred for LINQ. |
| **Example** | `delegate(int x) { return x * x; };` | `x => x * x;` |

---

## Core Advanced Concepts

### 1. Reflection
Reflection allows us to inspect metadata at runtime. We can look into a class to see its properties, methods, and attributes without knowing them beforehand. This is heavily used by frameworks like ASP.NET Core for Dependency Injection and Routing.

### 2. Generics
Generics allow us to write code that is independent of data types. Instead of writing separate methods for `int`, `string`, or `Student`, we use a placeholder `<T>`. This ensures type safety and code reusability.

---

## Transition to Web
### ASP.NET vs. ASP.NET Core
- **ASP.NET**: The legacy framework, tied specifically to Windows and IIS.
- **ASP.NET Core**: The modern, open-source, and cross-platform version. It is faster, modular, and optimized for cloud applications.

### SOLID Principles in Web Architecture
In web development, maintaining a clean codebase is crucial. **SOLID Principles** help us build decoupled systems:
- **Single Responsibility**: A controller should only handle requests, not business logic.
- **Dependency Inversion**: High-level modules should not depend on low-level modules; both should depend on abstractions (Interfaces).

---
*Created as part of Wipro Training 2026.*
