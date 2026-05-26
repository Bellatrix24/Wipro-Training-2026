# Day 21: ADO.NET Connected Architecture & Parameterized Queries - Trainee Notes

Hello! This is my personal diary/notes for Day 21 of our training. Today we dove into ADO.NET (ActiveX Data Objects for .NET) and figured out how C# apps can talk directly to SQL databases. Below are the key takeaways from today's labs, written in plain English as I understood them.

---

## What is ADO.NET?

Simply put, **ADO.NET** is the built-in database access framework inside Microsoft .NET. It acts as the translation layer between our C# application and the database engine (like SQL Server). 
* Think of it as a set of standard classes (`SqlConnection`, `SqlCommand`, `SqlDataReader`) that package up our queries and ship them off to the database using specialized drivers.
* It is extremely fast and low-level because it does not have the overhead of heavy frameworks. We write raw SQL queries, and ADO.NET executes them directly.

---

## Connected vs. Disconnected Data Access Style

We spent quite a bit of time today comparing these two styles of talking to databases. Here is the breakdown:

### Connected Style
This is what we focused on in today's coding labs.
* **How it works:** We keep a live, open physical connection (using `SqlConnection`) to the database server during the entire read/write operation. We use a fast, forward-only cursor called `SqlDataReader` to pull records one-by-one directly from the server.
* **Pros:** Extremely fast retrieval, very low memory footprint on our application's side because we don't load the whole table at once. Excellent for real-time applications.
* **Cons:** It holds onto database connection resources. If we forget to close the line, the database server can quickly run out of available connection slots.
* **Trainee Reminder:** *Keep the connection open for the absolute shortest time possible, and always close it when done!*

### Disconnected Style
* **How it works:** Instead of keeping the line open, we use a middleman called a `DataAdapter`. The adapter opens the connection, runs the query, dumps all the matching rows into an in-memory data bucket called a `DataSet` (or `DataTable`), and immediately closes the connection.
* **Pros:** Highly scalable. It releases database resources instantly, letting hundreds of other users use the connection pool.
* **Cons:** Takes up more memory in the C# application because the entire result set is stored in RAM. It's also slightly slower for simple reads due to the extra setup.

---

## Why We Use Parameters

One of the biggest security lessons today was about **SQL Injection**. 

When we stitch raw strings together to make a query, like this:
```csharp
string badQuery = "SELECT * FROM Students WHERE Name = '" + userInput + "'";
```
If a user inputs `' OR '1'='1`, the database runs:
```sql
SELECT * FROM Students WHERE Name = '' OR '1'='1'
```
This bypasses security and returns everything! Even worse, they could write `' ; DROP TABLE Students; --` and delete our whole lab database.

### The Fix: Parameterized Queries
By using parameter tags (like `@name` and `@age`), we tell the ADO.NET engine exactly what data type to expect. 
* The driver takes the input and treats it purely as literal **raw data values**, never as executable SQL commands.
* If a hacker inputs SQL commands into a parameter, the engine just searches for a student whose name literally matches that long SQL string. Nothing gets broken!

---

## Upcoming Topics: Entity Framework Core & AJAX

We got a brief sneak peek at what's coming up next in our training:

### Entity Framework Core (EF Core)
* **What is it?** It is an Object-Relational Mapper (ORM). 
* Instead of manually writing `INSERT INTO` or `SELECT *` strings in C#, EF Core lets us define normal C# classes (like `public class Student { ... }`) and automatically writes the database tables and SQL statements for us in the background. It is a huge time-saver!

### AJAX (Asynchronous JavaScript and XML)
* **What is it?** A web design technique used in the browser.
* Instead of reloading the entire web page just to fetch one piece of info, AJAX lets JavaScript make a silent background call to our C# server, grab the data, and update only that specific tiny widget on the page. It makes web apps feel super smooth and instant!
