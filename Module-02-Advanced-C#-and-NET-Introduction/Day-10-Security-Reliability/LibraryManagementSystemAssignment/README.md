# Library Management System Assignment (Day 10)

Welcome to the Day 10 Security and Reliability coding assignment! This project implements a clean, beginner-friendly **Library Management System** in C# and incorporates comprehensive unit tests using the **MSTest** framework to ensure robust reliability and transaction accuracy under typical and edge cases.

---

## Objective

The objective of this assignment is to design and develop an in-memory Library Management System in .NET 8+ and implement structured unit testing with MSTest. It demonstrates:
- Object-oriented design with logical dependencies (`Book`, `Borrower`, and `Library`).
- Application state mutation (borrowing and returning books).
- Happy path testing, parameter validation, and edge case testing.

---

## Folder Structure

Below is the directory layout of this assignment:

```text
LibraryManagementSystemAssignment/
├── LibraryManagementSystemAssignment.sln  # Solution file
├── README.md                              # This documentation file
│
├── LibraryManagementSystem/               # Core Application Logic
│   ├── LibraryManagementSystem.csproj     # Project configuration file
│   ├── Book.cs                            # Represents a book entity
│   ├── Borrower.cs                        # Represents library borrowers
│   └── Library.cs                         # Coordinates library transactions
│
└── LibraryManagementSystem.Tests/         # MSTest Unit Test Project
    ├── LibraryManagementSystem.Tests.csproj
    └── LibraryTests.cs                    # 12 comprehensive unit test cases
```

---

## Classes Created

### 1. `Book`
Represents an individual book with its author, title, ISBN, and borrowing status.
- **Properties**: `Title` (string), `Author` (string), `ISBN` (string), `IsBorrowed` (bool)
- **Methods**:
  - `Borrow()`: Marks the book as borrowed (`IsBorrowed = true`).
  - `Return()`: Marks the book as available (`IsBorrowed = false`).

### 2. `Borrower`
Represents a library cardholder and tracks their current list of borrowed books.
- **Properties**: `Name` (string), `LibraryCardNumber` (string), `BorrowedBooks` (List<Book>)
- **Methods**:
  - `BorrowBook(Book book)`: Adds the book to the borrower's list and calls `book.Borrow()`.
  - `ReturnBook(Book book)`: Removes the book from the borrower's list and calls `book.Return()`.

### 3. `Library`
Coordinates all library assets and registers cardholders. It serves as the primary gateway for transactions.
- **Properties**: `Books` (List<Book>), `Borrowers` (List<Borrower>)
- **Methods**:
  - `AddBook(Book book)`: Registers a book (returns `bool` success).
  - `RegisterBorrower(Borrower borrower)`: Registers a new user (returns `bool` success).
  - `BorrowBook(string isbn, string libraryCardNumber)`: Performs transaction logic (returns `bool` success).
  - `ReturnBook(string isbn, string libraryCardNumber)`: Handles returns (returns `bool` success).
  - `ViewBooks()`: Returns the complete list of books (`List<Book>`).
  - `ViewBorrowers()`: Returns the complete list of borrowers (`List<Borrower>`).

---

## Features Implemented

1. **In-Memory Storage**: Manages books and borrower lists using strongly typed C# generic lists.
2. **Robust Validation**:
   - Blocks duplicate ISBN entries.
   - Blocks duplicate library card registrations.
   - Prevents borrowing books that are already borrowed.
   - Prevents returns of books that are not borrowed or not associated with the borrower.
3. **Transaction Coordination**: Links `Book` and `Borrower` states cleanly when performing borrows/returns.

---

## How to Build the Project

Ensure you have the .NET SDK installed. Open a terminal at the `LibraryManagementSystemAssignment/` root directory and execute:

```bash
dotnet build
```

This compiles both projects with zero errors and zero warnings.

---

## How to Run Tests

To run the unit tests, execute:

```bash
dotnet test
```

This command automatically executes all 12 MSTest test cases and reports the outcome directly to your console.

---

## Testing Summary

We developed **12 total test cases** to cover every requirement and prospective edge case:

| # | Test Case Name | Method Tested | Expected Behavior |
|---|---|---|---|
| 1 | `AddBook_AddsBookToLibrary` | `AddBook` | Book is successfully added to the catalog |
| 2 | `RegisterBorrower_AddsBorrowerToLibrary` | `RegisterBorrower` | Borrower is successfully added to the system |
| 3 | `BorrowBook_MarksBookAsBorrowed` | `BorrowBook` | `IsBorrowed` state becomes `true` |
| 4 | `BorrowBook_AddsBookToBorrower` | `BorrowBook` | Book is appended to borrower's `BorrowedBooks` list |
| 5 | `ReturnBook_MarksBookAsAvailable` | `ReturnBook` | `IsBorrowed` state returns to `false` |
| 6 | `ReturnBook_RemovesBookFromBorrower` | `ReturnBook` | Book is removed from borrower's list |
| 7 | `ViewBooks_ReturnsAllBooks` | `ViewBooks` | Correctly lists all added books |
| 8 | `ViewBorrowers_ReturnsAllBorrowers` | `ViewBorrowers` | Correctly lists all registered borrowers |
| 9 | `BorrowBook_WithInvalidIsbn_ReturnsFalse` | `BorrowBook` | Attempting to borrow a non-existent book returns `false` |
| 10 | `BorrowBook_WithInvalidLibraryCard_ReturnsFalse` | `BorrowBook` | Attempting to borrow with an invalid card returns `false` |
| 11 | `BorrowBook_WhenBookAlreadyBorrowed_ReturnsFalse`| `BorrowBook` | Attempting to borrow an already checked-out book returns `false` |
| 12 | `ReturnBook_WhenBookWasNotBorrowed_ReturnsFalse` | `ReturnBook` | Attempting to return a book not checked out returns `false` |

### Statistics
- **Discovered Tests**: 12
- **Passed Tests**: 12
- **Failed Tests**: 0
- **Build Status**: Succeeded with 0 Warnings and 0 Errors

All 12 test cases successfully pass!
