# Day 12: Advanced SOLID Refactoring and Database Schema Design

## Overview
Today's training marked a significant transition from Software Architecture patterns to Data Persistence fundamentals. We explored how to refactor monolithic systems into modular, maintainable code using SOLID principles and laid the groundwork for relational database design using SQL.

### Key Transitions
- **From Logic to Data**: Moving from in-memory object management to persistent relational storage.
- **From Classes to Tables**: Mapping real-world entities like `Employees` to database schemas.
- **From Interfaces to Constraints**: Ensuring data integrity through SQL constraints (PK, NOT NULL) similar to how we use interfaces in C#.

---

## SOLID Refactoring: Digital Wallet Tasks (T1-T10)

The following mapping shows how the Applied SOLID principles were integrated into the `DigitalWalletRefactoring.cs` project:

| Task ID | Component / Action | Applied SOLID Principle |
| :--- | :--- | :--- |
| **T1** | Definition of `IPayment` interface | **DIP** (Dependency Inversion) |
| **T2** | `UpiPayment` implementation | **OCP** (Open/Closed Principle) |
| **T3** | `CardPayment` implementation | **OCP** / **LSP** |
| **T4** | `NetBankingPayment` implementation | **OCP** / **LSP** |
| **T5** | `INotificationService` abstraction | **ISP** (Interface Segregation) |
| **T6** | `EmailNotification` class | **SRP** (Single Responsibility) |
| **T7** | `TransactionLogger` class | **SRP** |
| **T8** | `OrderService` orchestration | **DIP** (Depends on abstractions) |
| **T9** | Swappable payment methods in `OrderService` | **LSP** (Liskov Substitution) |
| **T10** | Adding new payment methods without core logic changes | **OCP** |

---

## Technical Summary

### 1. SOLID Refactoring
- **SRP**: Separated payment processing, notification, and logging into distinct classes.
- **OCP**: The system is open for extension (new payment methods) but closed for modification.
- **LSP**: All payment types (`UPI`, `Card`, `NetBanking`) can be substituted for `IPayment` without breaking `OrderService`.
- **ISP**: Small, specific interfaces (`IPayment`, `INotificationService`) ensure clients only depend on what they use.
- **DIP**: High-level modules (`OrderService`) do not depend on low-level modules; both depend on abstractions.

### 2. SQL Database Design
- **Schema Design**: Created `CompanyDB` with an `Employees` table using robust constraints.
- **Querying**: Implemented DML queries to filter and manage employee data.
- **Relational Concepts**: Documented Joins, Subqueries, Indexing, and Transactions for performance and integrity.
