# Calculator Unit Testing Assignment (Day 10)

Welcome to the Day 10 Security and Reliability training assignment! This project demonstrates how to structure and write robust unit tests for a standard C# class library using the **MSTest** testing framework in **.NET 8+**.

---

## Assignment Objective

The objective of this assignment is to understand the fundamentals of unit testing in .NET, practice writing test cases with diverse inputs (valid ranges, decimals, negative numbers, zero edge cases), and implement exception testing (specifically for division by zero).

By writing unit tests, we build reliable and resilient software that behaves predictably under edge case scenarios.

---

## Folder Structure

Below is the directory layout of this assignment:

```text
CalculatorUnitTestingAssignment/
├── CalculatorUnitTestingAssignment.sln    # Solution combining both projects
├── README.md                              # This documentation file
│
├── CalculatorLibrary/                     # Core Logic Class Library
│   ├── CalculatorLibrary.csproj           # Project configuration
│   └── Calculator.cs                      # Calculator implementation
│
└── CalculatorLibrary.Tests/               # MSTest Unit Test Project
    ├── CalculatorLibrary.Tests.csproj     # Test project configuration
    ├── CalculatorTests.cs                 # 10 comprehensive unit test cases
    └── MSTestSettings.cs                  # MSTest configuration assembly settings
```

---

## How to Build the Project

Ensure you have the .NET SDK installed. To build the entire solution, open a terminal (PowerShell, Command Prompt, or terminal of choice) inside the `CalculatorUnitTestingAssignment/` folder and run:

```bash
dotnet build
```

This will compile both the `CalculatorLibrary` class library and the `CalculatorLibrary.Tests` project.

---

## How to Run Tests

To run the unit tests, run the following command in the same directory:

```bash
dotnet test
```

This command automatically discovers all unit tests in the solution, executes them, and prints the results directly to the console.

---

## Testing Summary

The unit test suite consists of **10 comprehensive test cases** designed to cover both typical paths and edge cases for the calculator operations:

| Test Case Name | Method Tested | Input Scope | Expected Behavior |
|---|---|---|---|
| `Add_ReturnsCorrectSum` | `Add` | Standard decimal inputs | Correctly adds two positive values |
| `Add_WithZero_ReturnsSameNumber` | `Add` | Zero addition | Adding zero returns the original value |
| `Subtract_ReturnsCorrectDifference` | `Subtract` | Standard decimal inputs | Correctly subtracts two values |
| `Subtract_WithZero_ReturnsSameNumber` | `Subtract` | Zero subtraction | Subtracting zero returns the original value |
| `Multiply_ReturnsCorrectProduct` | `Multiply` | Standard decimal inputs | Correctly multiplies two values |
| `Multiply_WithZero_ReturnsZero` | `Multiply` | Zero multiplication | Multiplying by zero returns zero |
| `Divide_ReturnsCorrectQuotient` | `Divide` | Standard decimal inputs | Correctly divides two values |
| `Divide_WithDecimalNumbers_ReturnsCorrectResult` | `Divide` | Decimal numbers | Accurately divides and compares decimals |
| `Divide_ByZero_ThrowsDivideByZeroException` | `Divide` | Division by zero edge case | Throws a `DivideByZeroException` with message "Cannot divide by zero." |
| `Operations_WithNegativeNumbers_ReturnCorrectResults` | All | Negative inputs | Verifies negative number calculations |

### Key Testing Elements used:
- **`Assert.AreEqual`**: Used for validating normal numeric result calculations.
- **Delta Parameter (`0.0001`)**: Used in floating-point double comparisons to avoid rounding errors.
- **`Assert.ThrowsException<DivideByZeroException>`**: Used to verify that division by zero results in a correct application exception.

---

## Verification Result

All 10 test cases run and pass flawlessly:

```text
Passed!  - Failed:     0, Passed:    10, Skipped:     0, Total:    10, Duration: 75 ms
```
