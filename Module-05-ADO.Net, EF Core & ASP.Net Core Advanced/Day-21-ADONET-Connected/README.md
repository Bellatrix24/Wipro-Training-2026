# Day 21: ADO.NET Connected Architecture Basics

This folder holds my notes and lab scripts from today's training. We focused on database connectivity in .NET using ADO.NET, learning how to write secure queries, stream records, and manage physical connection pipelines.

---

## Overview of Daily Learning

Today's main goal was to establish a direct connection between our C# application and a Microsoft SQL Server database. 

We focused on the **Connected Architecture**, which relies on a continuous, live pipeline to the database during operations. We learned how to:
1. Open a physical connection pathway to a local database.
2. Execute data manipulation queries safely.
3. Use a fast streaming cursor to display rows on the console.
4. Protect our databases against malicious attacks.

---

## Setting Up the Database Driver Package

To make C# talk to SQL Server, we need a specialized driver. In modern .NET, we install the official NuGet package:

```bash
dotnet add package Microsoft.Data.SqlClient
```

This package gives us access to core classes like:
* `SqlConnection`: Establishes the physical pipeline to the SQL database.
* `SqlCommand`: Holds and delivers the SQL statement we want to run.
* `SqlDataReader`: Streams rows one-by-one in a fast, forward-only manner.

---

## Verification Labs Completed Today

We verified our setup by building and running three key lab operations inside [StudentAdoDemo_Program.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-21-ADONET-Connected/StudentAdoDemo_Program.cs):

### 1. Direct Row Insertion
* We ran a basic `INSERT INTO Students` query using standard SQL commands.
* We verified execution using the `ExecuteNonQuery()` method, which successfully returned the number of rows affected.

### 2. Parameterized Database Ingestion
* To prevent security flaws like SQL Injection, we verified the parameterized approach.
* Using placeholders (`@name` and `@age`) coupled with `Parameters.AddWithValue()`, we ensured that user inputs are treated strictly as data values instead of executable instructions.

### 3. Record Retrieval and Console Stream Output
* We ran a standard `SELECT * FROM Students` statement.
* We mapped the result handle to a `SqlDataReader` and looped through the records using `while (dr.Read())` to print all data fields cleanly on the terminal stream.
* We ensured the reader and the connection are both closed safely when done to prevent server resource leaks.

---

## Repository Tracking

Our progress is tracked within the central repository target:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
