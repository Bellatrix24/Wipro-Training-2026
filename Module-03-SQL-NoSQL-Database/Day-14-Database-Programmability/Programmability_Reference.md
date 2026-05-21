# Learning Notes: Database Programmability (Functions & Procedures)

Today I learned how to move logic into the database using Microsoft SQL Server. This is called database programmability, and it helps write cleaner, faster, and more modular applications. Here is a breakdown of what I learned.

---

### Why do we use Functions and Procedures?

Instead of writing complex SQL queries inside our C# backend or calling raw commands over and over, we can save code blocks directly in the database. 

*   **Code Reusability**: We write the calculation or formatting rules once, and then any query can use them.
*   **Cleaner Code**: Our queries look much simpler. For example, instead of concatenating first and last names in every report query, we just call our function.
*   **Centralized Updates**: If the rules change (like a bonus percentage changing from 10% to 12%), we only need to change it in one spot in the database. We don't have to recompile and re-deploy our whole C# application.
*   **Saves Network Traffic**: Instead of pulling all database rows over the network to the application just to calculate a simple value, we do the math directly on the database server. This returns just the final result, saving time and bandwidth.

---

### Types of Functions I Learned Today

Functions in SQL Server help calculate or format values. They take some input parameters and always return something.

#### 1. Scalar Functions
*   **What they do**: They take some inputs and return exactly **one value** (like a single string, number, or date).
*   **Example**: `dbo.GETFULLNAME` takes first and last names and returns a single concatenated string. `dbo.CalculateBonus` takes a salary and returns a single decimal value.
*   **How we use them**: We use them inside SELECT lists or WHERE clauses just like standard variables.

#### 2. Table-Valued Functions (TVF)
*   **What they do**: Instead of returning just one value, they return a **whole table** of data.
*   **Example**: `dbo.GetEmployeebyDept` takes a department name and returns a set of matching employee records.
*   **How we use them**: Since they return a table, we can use them inside a `FROM` clause and even join them with other tables!
*   **Why they are cool**: They are super fast because SQL Server treats them like normal queries (parameterized views) and optimizes them easily.

#### 3. System Functions
*   **What they do**: These are the built-in functions that SQL Server provides automatically.
*   **Examples**: Aggregate tools like `SUM()` or `COUNT()`, string helpers like `LTRIM()`, and system helpers like `GETDATE()`.

---

### Functions vs Stored Procedures (Learner's Perspective)

It was a bit confusing at first to know when to write a Function and when to write a Stored Procedure. Here is how I remember the difference:

*   **Use Functions when you just want to calculate, format, or fetch data.**
    *   Functions must always return a value (or table).
    *   They are "read-only" and are not allowed to modify data in the tables.
    *   You can call them directly inside a SELECT query or a JOIN.
*   **Use Stored Procedures when you need to actually do something (like modify data).**
    *   Procedures are great for CRUD operations, like inserting a new employee record (`dbo.ADDEMPLOYEE`).
    *   They are allowed to use transactions so we can commit or rollback changes if something goes wrong.
    *   You call them using the `EXEC` keyword.

---

### Things to Keep in Mind

*   **Math Safety**: Always make sure numeric calculations (like `Salary * 0.10`) handle decimal points properly so SQL doesn't truncate the numbers.
*   **Database Constraints**: When writing procedures to insert data, always make sure we provide fields that have a `NOT NULL` constraint (like `Age` in our `Employees` table) or set a safe default value so the insert doesn't crash.
