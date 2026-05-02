# Design Patterns Summary

### Definition of Design Patterns
- **What they are:** Reusable solutions to commonly occurring problems in software development.
- **Concept:** They are not actual code, but rather proven approaches or templates that you apply to specific situations.
- **Analogy:** Think of a design pattern like a cooking recipe; it provides the steps and logic, but you still have to write the code (cook the dish) yourself.

### The 3 Main Categories
- **Creational:** Deals with how objects are created. They control the instantiation process in your program.
- **Structural:** Focuses on how objects fit together. They define how classes and objects are composed to form larger structures.
- **Behavioral:** Manages how objects communicate. They handle the interaction and responsibility sharing between objects.

### Comparison between Singleton and Observer Patterns
- **Singleton Pattern:**
  - **Purpose:** Ensures only *one instance* of a class exists throughout the entire application.
  - **Communication:** Everyone shares the same single object.
  - **Real-world Examples:** Database connections, application loggers, configuration settings.
- **Observer Pattern:**
  - **Purpose:** Allows *one object to notify many others* when its state changes.
  - **Communication:** One-to-many communication (1 event → many listeners).
  - **Real-world Examples:** YouTube subscriptions, push notifications, stock price alerts.

### Benefits for Software Maintenance
- **Cleaner Code:** Reduces duplication and increases clarity in the codebase.
- **Reusability:** Allows developers to apply the same proven solutions across new projects.
- **Easy Maintenance:** Makes the code easier for teammates to read, understand, and update over time.
- **Industry Standard:** Being widely used, design patterns are expected by engineering teams, establishing a common vocabulary.
