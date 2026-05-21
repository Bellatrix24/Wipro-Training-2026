# Day 15: Subqueries and Triggers

## Daily Summary
Today's study focus was learning how to nest queries inside other queries (subqueries) and set up automatic actions (triggers) directly inside the database layer. 

Running queries inside queries is incredibly useful for filtering data based on dynamic calculations (like finding employees who make more than the company average). Triggers act as automatic background hooks that fire when data changes, allowing us to perform tasks like updating department locations or keeping logs without having to write separate commands in our backend C# code.

---

## Performance Optimization Tip

One of the most important concepts to remember is that while subqueries are easy to write and read for small lookups, they can sometimes run row-by-row and slow down our system. Learning how and when to rewrite a subquery into a standard `JOIN` is a great trick for database optimization. It helps the SQL Server engine build a faster query plan and handle large tables efficiently.

---

## File Contents in this Folder

*   [Subqueries_And_Triggers_Practice.sql](./Subqueries_And_Triggers_Practice.sql): Clean, conversational SQL script implementing the Departments table, multiple subquery exercises (scalar, `IN`, and correlated), an AFTER INSERT trigger, and transactional tests.
*   [Subqueries_Triggers_Notes.md](./Subqueries_Triggers_Notes.md): My personal study notes comparing subqueries vs. joins, detailing trigger use cases, trigger types, and notes on why we should be careful using triggers in production.

---

## Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 03 (SQL, NoSQL, and Microsoft SQL Server Database Systems)
*   **Target Scope**: Day 15 - Subqueries and Triggers
