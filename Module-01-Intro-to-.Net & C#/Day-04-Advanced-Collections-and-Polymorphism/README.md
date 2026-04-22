# Day 4: Advanced Collections, LINQ, and Polymorphism

## Today's Learning Summary
Today was all about how we store and manage data efficiently in C#. We moved beyond simple arrays and explored complex collection types and the power of Polymorphism.

### 1. Generic Collections
- **List<T>, Dictionary<K,V>, Queue<T>, Stack<T>**: These are type-safe and efficient.
- **Memory Management**: We learned how the CLR handles **dynamic resizing**. For example, when a List exceeds its capacity, the CLR allocates a larger memory block and moves the elements.

### 2. Non-Generic Collections
- Practiced with **Hashtable** and **Stack (System.Collections)**.
- **The Risk**: These collections store everything as `object`, which leads to boxing/unboxing issues and a lack of type safety (bugs might only show up at runtime!).

### 3. LINQ Basics
- Learned how to use `.Where()` for filtering and `.Select()` for transforming data. It makes code much cleaner than using multiple loops!

### 4. Polymorphism (Method Overriding)
- Explored how a base class can have a `virtual` method that is specialized by a child class using the `override` keyword. This allows for flexible "many forms" behavior.

---

## Folder Structure
- `GenericCollections.cs`: Demo with mobile phone data and LINQ.
- `NonGenericDemo.cs`: Example showing the risks of mixed-type collections.
- `EcommerceScenario.cs`: A practical Order Management simulation using various collections.
- `PolymorphismDemo.cs`: Simple example of method overriding with Orders.

*Created as part of the Wipro .NET Training Program - April 2026*
