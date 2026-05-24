# SOLID Principles & Design Patterns Assignment (Day 10)

Welcome to the Day 10 SOLID Principles & Design Patterns coding assignment! This project implements a clean, beginner-friendly system in C# demonstrating the five **SOLID Principles** of object-oriented design and the **Factory Method Design Pattern**. It incorporates comprehensive unit tests using the **MSTest** framework to verify each design pattern and principle requirement under typical and edge cases.

---

## Objective

The objective of this assignment is to design a codebase following best practices in software design, split into two primary areas:
1. **SOLID Principles**: Build a reporting system structured to satisfy the Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion principles.
2. **Factory Design Pattern**: Implement a document creation system that decouples object instantiation from the client using a centralized factory class.

---

## Folder Structure

Below is the directory layout of this assignment:

```text
SolidDesignPatternsAssignment/
├── SolidDesignPatternsAssignment.sln          # Solution file
├── README.md                                  # This documentation file
│
├── SolidDesignPatterns/                       # Core Application Logic
│   ├── SolidDesignPatterns.csproj             # Project configuration file
│   ├── SOLID/                                 # SOLID Reporting System
│   │   ├── Models/
│   │   │   ├── Report.cs                      # Abstract base LSP model
│   │   │   ├── SalesReport.cs                 # Derived Sales report
│   │   │   └── InventoryReport.cs             # Derived Inventory report
│   │   ├── Interfaces/
│   │   │   ├── IReportContent.cs              # Core content representation
│   │   │   ├── IReportFormatter.cs            # Formatting contract (OCP)
│   │   │   ├── IReportSaver.cs                # Storage contract (SRP)
│   │   │   └── IReportGenerator.cs            # Compilation contract (SRP)
│   │   ├── Formatters/
│   │   │   ├── PdfReportFormatter.cs          # Formats PDF reports (OCP)
│   │   │   └── ExcelReportFormatter.cs        # Formats Excel reports (OCP)
│   │   └── Services/
│   │       ├── ReportGenerator.cs             # Content compilation engine
│   │       ├── ReportSaver.cs                 # Disk saving coordinator
│   │       └── ReportService.cs               # Orchestrator relying on DIP
│   └── DesignPatterns/                        # Design Patterns
│       └── Factory/
│           ├── IDocument.cs                   # Common document interface
│           ├── PdfDocument.cs                 # Concrete PDF product
│           ├── WordDocument.cs                # Concrete Word product
│           └── DocumentFactory.cs             # Central factory creator class
│
└── SolidDesignPatterns.Tests/                 # MSTest Unit Test Project
    ├── SolidDesignPatterns.Tests.csproj
    ├── MSTestSettings.cs                      # Enforces sequential tests on disk
    ├── SolidPrinciplesTests.cs                # 8 tests validating SOLID behaviors
    └── FactoryPatternTests.cs                 # 4 tests validating Factory behavior
```

---

## Design Designations & Architecture

### Part 1: SOLID Principles reporting system
*   **Single Responsibility Principle (SRP)**: Handled by splitting report creation and writing. `ReportGenerator` compiles raw report text from models, while `ReportSaver` solely writes formatted reports to disk.
*   **Open/Closed Principle (OCP)**: Implemented through `IReportFormatter`. If a new format is needed (e.g., HTML, XML), you can introduce a new class implementing `IReportFormatter` without modifying any existing generator or saver code.
*   **Liskov Substitution Principle (LSP)**: `SalesReport` and `InventoryReport` extend the abstract `Report` base class. Calling methods can substitutionally use `Report` references transparently without having to know about or handle downstream type-specific issues.
*   **Interface Segregation Principle (ISP)**: Segregated narrow interfaces (`IReportContent`, `IReportFormatter`, `IReportSaver`, `IReportGenerator`) ensure that classes only implement methods they absolutely require.
*   **Dependency Inversion Principle (DIP)**: `ReportService` coordinates the pipeline but depends completely on the interfaces (`IReportGenerator`, `IReportFormatter`, `IReportSaver`) injected via its constructor rather than concrete implementation details.

### Part 2: Factory Design Pattern
*   **Decoupled Creation**: Concrete classes `PdfDocument` and `WordDocument` implement `IDocument`.
*   **DocumentFactory**: Validates strings and returns instances of the polymorphic contract `IDocument`. This isolates client code from changes in the underlying concrete products or the construction parameters.

---

## How to Build the Project

Ensure you have the latest .NET Core SDK installed. Open a terminal at the `SolidDesignPatternsAssignment/` root directory and execute:

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

We developed **12 total test cases** to cover every requirement and design principle:

| # | Test Case Name | Principle/Pattern | Expected Behavior |
|---|---|---|---|
| 1 | `ReportGenerator_GeneratesReportContent` | SRP | Correctly fetches raw details from a report model. |
| 2 | `ReportSaver_SavesReportContent` | SRP | Successfully saves content to local disk files. |
| 3 | `PdfFormatter_FormatsReportAsPdf` | OCP | Returns formatted layout containing `[PDF FORMAT]`. |
| 4 | `ExcelFormatter_FormatsReportAsExcel` | OCP | Returns formatted layout containing `[EXCEL FORMAT]`. |
| 5 | `SalesReport_CanBeUsedAsBaseReport` | LSP | Can substitute parent `Report` without errors or changes. |
| 6 | `InventoryReport_CanBeUsedAsBaseReport` | LSP | Can substitute parent `Report` without errors or changes. |
| 7 | `ReportService_UsesInjectedDependencies` | DIP / Mocking | Verifies that abstract dependencies are invoked. |
| 8 | `ReportService_CreateAndSaveReport_ReturnsTrue`| DIP / Integration | Verifies the orchestrated service successfully runs end-to-end. |
| 9 | `DocumentFactory_CreatesPdfDocument` | Factory Pattern | Factory string `"pdf"` yields `PdfDocument` typed entity. |
| 10 | `DocumentFactory_CreatesWordDocument` | Factory Pattern | Factory string `"word"` yields `WordDocument` typed entity. |
| 11 | `DocumentFactory_WithInvalidType_ThrowsArgumentException` | Factory Pattern | Unsupported types correctly throw `ArgumentException`. |
| 12 | `PdfAndWordDocuments_ImplementSameInterface` | Polymorphism | Both products inherit and can be referenced via `IDocument`. |

### Statistics
- **Discovered Tests**: 12
- **Passed Tests**: 12
- **Failed Tests**: 0
- **Build Status**: Succeeded with 0 Warnings and 0 Errors

All 12 test cases successfully pass!
