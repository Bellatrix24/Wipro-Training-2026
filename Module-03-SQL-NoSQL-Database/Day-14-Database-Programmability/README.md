# Day 14: Database Programmability (Functions and Stored Procedures)

## Objective Summary
Today's goal was to learn how to write and use programmable objects in Microsoft SQL Server, specifically **Functions** (Scalar and Table-Valued) and **Stored Procedures**. This layer of database programmability helps keep our relational database neat, reusable, and secure.

---

## Why We Move Logic to SQL Server (Network Benefits)

When we write database calculations and rules inside SQL Server instead of our backend C# application, we gain a major performance advantage:

*   **No Raw Data Round-Trips**: Without functions or procedures, the backend application has to pull entire tables of raw records over the network, do the calculations in C# memory, and then send updates back. This creates a lot of slow network traffic.
*   **Faster Local Calculations**: By saving our logic (like combining names or calculating bonuses) as functions and procedures in the database, the calculations happen directly on the SQL Server. The backend app only sends a tiny command and gets back just the exact result it needs. This saves network trip time and makes the overall application feel much more responsive.

---

## What is in this Folder

*   [Database_Programmability.sql](./Database_Programmability.sql): Simple, clean T-SQL script containing our functions (`dbo.GETFULLNAME`, `dbo.CalculateBonus`, `dbo.GetEmployeebyDept`) and the stored procedure (`dbo.ADDEMPLOYEE`). It also contains friendly test calls wrapped in transactions so our test data stays clean.
*   [Programmability_Reference.md](./Programmability_Reference.md): A plain English student study guide and learning notes on why we use functions, their types, and the differences between functions and stored procedures.

---

## Tracking and Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 03 (SQL, NoSQL, and Microsoft SQL Server Database Systems)
*   **Training Phase**: Wipro Project Engineer Trainee (NGA)
