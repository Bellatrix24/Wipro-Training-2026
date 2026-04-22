# Day 7: Searching Algorithms, Indexers, and File Handling

Welcome to Day 7 of my .NET training! Today's session focused on efficient data searching techniques, the power of indexers in C#, and persistent storage using File I/O operations.

## 1. Searching Algorithms Comparison

Searching is a fundamental operation in programming. Depending on whether the data is sorted or unsorted, we choose between these two primary algorithms:

| Feature | Linear Search | Binary Search |
| :--- | :--- | :--- |
| **Requirement** | Works on both sorted and unsorted data. | **Must** be performed on sorted data. |
| **Complexity** | O(n) - Linear Time | O(log n) - Logarithmic Time |
| **Efficiency** | Slower for large datasets. | Extremely fast for large datasets. |
| **Approach** | Checks every element sequentially. | Uses Divide and Conquer (halving the search area). |

## 2. Indexers vs. Properties

In C#, both Indexers and Properties are used for encapsulation, but they serve different purposes:

*   **Properties:** Represent the **attributes** or data of an object (e.g., Name, Price, Age). They are accessed using a name.
*   **Indexers:** Allow an object to be treated like an **array**. They enable us to access internal collections using the `this[]` keyword and an index (usually an integer or string).

> **Key Takeaway:** If a class represents a single entity, use properties. If a class represents a collection of items, use an indexer.

## 3. File Handling in C#

File handling allows us to store data permanently on a disk. The `System.IO` namespace provides the necessary classes for these operations.

### Basic Steps:
1.  **Import Namespace:** `using System.IO;`
2.  **Specify Path:** Define where the file is located (e.g., `@"C:\myfolder\test.txt"`).
3.  **Choose Operation:** Create, Write, Append, or Read.
4.  **Handle Exceptions:** Always use `try-catch` blocks to handle issues like "File Not Found" or "Access Denied."

## 4. Real-World Use Cases

*   **Google Search Suggestions:** Uses **Binary Search** (among other complex algorithms) to quickly find matches in a sorted database of common queries.
*   **Banking Transactions:** Use **Merge Sort** (to organize records by timestamp) and searching to verify transaction IDs.
*   **E-commerce Inventory:** Use **Indexers** to quickly access products in a catalog by their unique ID or position.

---
*Learning Goal: Master the art of efficient data retrieval and persistent storage.*
