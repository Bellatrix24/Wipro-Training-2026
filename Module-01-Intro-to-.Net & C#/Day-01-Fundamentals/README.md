# Day 1: Getting Started with .NET Fundamentals

Hello! This is my first module at Wipro. Today, I began my journey with the .NET ecosystem. I've documented my session notes and practice work below to keep track of what I learned.

## .NET Architecture
I learned about the core components that make .NET work:
*   **CLR (Common Language Runtime):** The "engine" that handles running the applications, managing memory (Garbage Collection), and ensuring security.
*   **BCL (Base Class Library):** A huge collection of pre-written code (like for handling files, dates, and strings) that we can use so we don't have to reinvent the wheel.
*   **CTS (Common Type System):** A standard that ensures all .NET languages (C#, VB.NET, F#) use the same data types, making them compatible.
*   **CLS (Common Language Specification):** A set of rules that defines how different languages must behave so they can work together seamlessly.

## .NET Framework vs. .NET Core
It was interesting to see how the platform evolved:
*   **.NET Framework:** The original version, mostly for Windows-based desktop and web apps.
*   **.NET Core / .NET 5+:** The modern, cross-platform version. It's faster, lighter, and runs on Windows, Linux, and macOS. This is what we'll be using for our modern projects!

## Core Concepts

### Value Types vs. Reference Types
Understanding where data lives in memory was a big "Aha!" moment today.

| Feature | Value Types | Reference Types |
| :--- | :--- | :--- |
| **Storage** | Stored on the **Stack** | Stored on the **Heap** |
| **Data** | Contains the actual value | Contains a pointer/reference to the data |
| **Examples** | `int`, `bool`, `double`, `struct` | `string`, `object`, `class`, `array` |
| **Memory** | Fast access, automatically cleared | Managed by the Garbage Collector |

### String vs. StringBuilder
While both handle text, they work very differently under the hood:

| Feature | String | StringBuilder |
| :--- | :--- | :--- |
| **Mutability** | **Immutable** (cannot be changed) | **Mutable** (can be modified) |
| **Performance** | Creates a new object every time you modify it | Modifies the existing object in memory |
| **Use Case** | Best for small, unchanging text | Best for heavy text manipulation or loops |

---
*Looking forward to Day 2!*
