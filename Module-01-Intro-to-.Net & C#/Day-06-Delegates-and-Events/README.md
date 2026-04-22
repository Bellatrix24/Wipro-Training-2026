# Day 6: Delegates and Publisher-Subscriber Models

## Today's Learning Summary
Today we explored the world of **Delegates** and **Events**. We learned how to make our code more flexible by passing methods as arguments and creating a loosely coupled communication system called the Publisher-Subscriber model.

### 1. Delegates
- A delegate is like a **type-safe function pointer**. It holds a reference to a method with a specific signature.
- This allows us to decide which method to call at runtime!

### 2. Event Comparison Table
| Feature | Event Delegating Model | Publisher-Subscriber Model |
| :--- | :--- | :--- |
| **Coupling** | Direct (Tight) coupling. | Loosely coupled. |
| **Awareness** | The caller knows exactly which method they are calling. | The Publisher doesn't know who the Subscribers are. |
| **Medium** | Direct invocation via delegate instance. | Uses an Event or Message Bus as a middleman. |

### 3. Performance Tracking
- Learned how to use the `Stopwatch` class from `System.Diagnostics`. 
- It’s much more accurate than using `DateTime.Now` for measuring how long a block of code takes to execute.

---
*Created as part of the Wipro .NET Training Program - April 2026*
