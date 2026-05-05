# Design Patterns Technical Reference

## Architectural Categories

Modern software engineering relies on established design patterns to solve recurring architectural challenges. These are categorized based on their primary intent:

### 1. Creational Patterns
**Intent**: Object Creation Logic.  
These patterns abstract the instantiation process. They make a system independent of how its objects are created, composed, and represented.
- **Example**: Factory Method.

### 2. Structural Patterns
**Intent**: Class and Object Composition.  
These patterns focus on how classes and objects are composed to form larger structures. They use inheritance or interfaces to coordinate multiple objects.
- **Example**: Decorator.

### 3. Behavioral Patterns
**Intent**: Object Communication and Responsibility.  
These patterns characterize the ways in which classes or objects interact and distribute responsibility.
- **Examples**: Strategy, Observer.

---

## Implementation Mapping: E-Commerce Scenario

| Business Requirement | Design Pattern | Category | Technical Rationale |
| :--- | :--- | :--- | :--- |
| **Product Creation** | Factory Pattern | Creational | Decouples the client code from the concrete classes (Electronics/Clothing). |
| **Discount System** | Decorator Pattern | Structural | Allows dynamic modification of product prices without altering original classes. |
| **Payment Logic** | Strategy Pattern | Behavioral | Enables the selection of different payment algorithms (UPI/Card) at runtime. |
| **Order Updates** | Observer Pattern | Behavioral | Notifies external services (Notifications) about state changes in the order. |

---
*Reference Guide for Wipro Training 2026 - Day 13*
