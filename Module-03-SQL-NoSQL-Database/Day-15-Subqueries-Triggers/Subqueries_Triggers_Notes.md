# Study Notes: Queries Inside Queries and Automated Triggers

Today's learning was all about making our SQL queries more flexible using subqueries, and setting up automatic database hooks using triggers. Here are the simple learning notes I took.

---

### Subqueries vs. Joins

A subquery is basically a query nested inside another query (like inside a WHERE or FROM clause). Joins are used to link two tables together using common columns. 

Here is a comparison table to help me decide which one to use:

| Feature | Subqueries | Joins |
| :--- | :--- | :--- |
| **How it runs** | Simple subqueries run the inner part first to get a list or value, then the outer part filters by it. Correlated subqueries run row-by-row. | Joins combine matching rows from both tables together in memory at once. |
| **Readability** | Super easy to read for simple filters (like selecting employees earning above average). | Highly readable for complex queries joining 3 or more tables together. |
| **When to choose** | Use when you just need to filter records based on a single calculated value or list from another table. | Use when you actually need to select and show columns from multiple tables at the same time. |
| **Internal Optimizer Tip** | SQL Server is very smart! Its internal query optimizer often translates simple subqueries into JOINs anyway under the hood to speed things up. | Standard JOINs give the engine a clear plan from the start, making them highly efficient. |

---

### Common Trigger Use Cases

Triggers are special blocks of code that run automatically in response to certain events in the database. Here is why we use them in plain English:

*   **Keeping Audit Trails**: Automatically writing a log entry to a history table whenever a user updates or deletes critical data.
*   **Validating Fields**: Checking if values fall within safe boundaries before allowing them to save.
*   **Cascading Simple Logs**: Doing automatic side-effects, like updating a department status or writing a timestamp whenever a new row is added.

---

### Production Warnings (Why Seniors Say "Be Careful!")

Senior developers always advise against overusing triggers in large production databases. Here is why:

1.  **Hard to Debug**: Triggers run behind the scenes. If a query suddenly behaves weirdly or fails, it is hard to track down because the trigger code fires silently without showing up in the application's C# source code.
2.  **Hidden Memory and Performance Overhead**: Every time a trigger fires, SQL Server has to manage virtual tables in memory. 
3.  **Locks and Bottlenecks**: Doing massive inserts (like importing 10,000 employees at once) will trigger the code 10,000 times. This slows down database writes and can lock up tables, blocking other users.

---

### Different Types of Triggers

There are three main categories of triggers depending on what event they respond to:

*   **DML Triggers (Data Manipulation Language)**
    *   *Definition*: Triggers that automatically run when data in a table is modified (like on `INSERT`, `UPDATE`, or `DELETE` commands).
*   **DDL Triggers (Data Definition Language)**
    *   *Definition*: Triggers that automatically run when the structure of the database changes (like when a table is created, modified, or dropped).
*   **Logon Triggers**
    *   *Definition*: Triggers that run automatically whenever a user establishes a connection session to the SQL Server instance.
