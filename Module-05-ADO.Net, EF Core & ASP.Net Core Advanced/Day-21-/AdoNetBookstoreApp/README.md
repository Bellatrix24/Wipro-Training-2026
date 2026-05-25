# ADO.NET Bookstore Application

This project is a clean, single-solution ASP.NET Core MVC application developed as a training submission for Day 21. It demonstrates database operations using pure ADO.NET (SqlConnection, SqlCommand, SqlDataReader, SqlDataAdapter, DataSet, and DataTable) with parameterized queries and Stored Procedures, without any Entity Framework or ORM packages.

## Project Purpose

The purpose of this application is to demonstrate standard ADO.NET database operations in ASP.NET Core:
1. Bookstore CRUD: Using SqlCommand and SqlDataReader to list, view, add, edit, and delete books in SQL Server.
2. SQL Injection Prevention: Implementing parameterized queries to secure SQL execution.
3. Stored Procedures: Invoking Stored Procedures with parameters using CommandType.StoredProcedure.
4. Disconnected Architecture: Using SqlDataAdapter to fetch records into a disconnected DataSet/DataTable, adding rows disconnectedly, and writing modifications back to the database in batch.

*Note: This application is built using pure ADO.NET. It does not use Entity Framework Core or Dapper.*

## How to Configure Connection String

The application reads the connection string from the **appsettings.json** file located in the MVC project directory.

1. Open `appsettings.json`.
2. Locate the `ConnectionStrings` section.
3. Update the `DefaultConnection` value to match your SQL Server local instance (for example, using LocalDB):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BookstoreAdoDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

*Tip: If the SQL Server is offline, the application automatically falls back to a simulated in-memory mode so you can test all views, CRUD operations, and DataSet synchronization offline!*

## SQL Scripts Execution Order

Before running the application with a live database, execute the SQL scripts in the **DatabaseScripts/** folder in the following order:

1. **01_CreateDatabaseAndTable.sql**: Creates the `BookstoreAdoDb` database and the `Books` table if they do not exist.
2. **02_StoredProcedures.sql**: Registers the `AddBook`, `UpdateBook`, and `DeleteBook` stored procedures.
3. **03_SampleData.sql**: Populates the table with initial sample book records.

## How to Run the App

1. Open a terminal and navigate to the project directory:
   ```bash
   cd AdoNetBookstoreApp
   ```
2. Build the solution to verify code health:
   ```bash
   dotnet build
   ```
3. Run the web application:
   ```bash
   dotnet run --project AdoNetBookstoreApp
   ```
4. Open your browser and navigate to the local hosting address (usually http://localhost:5000 or http://localhost:5100).

## Routes to Test

* `/Books`: View the book catalog list (uses SqlDataReader).
* `/Books/Details/{id}`: View details for one book (uses secure parameterized SQL query).
* `/Books/Create`: Add a new book (uses AddBook Stored Procedure).
* `/Books/Edit/{id}`: Edit book details (uses UpdateBook Stored Procedure).
* `/Books/Delete/{id}`: Delete a book record (uses DeleteBook Stored Procedure).
* `/DataSetDemo`: Displays the disconnected DataTable grid. Submitting the form adds a disconnected row to the DataTable and synchronizes it using a SqlDataAdapter.
* `/SqlInjectionDemo`: Interactive console demonstrating parameterized queries vs unsafe dynamic concatenation side-by-side.

## Requirement Checklist

* Created a Book model with BookId, Title, Author, ISBN, and Price.
* Implemented Books CRUD views: Index, Details, Create, Edit, Delete.
* Utilized raw ADO.NET (SqlConnection, SqlCommand, SqlDataReader) inside BookDataAccess.cs.
* Protected every query against SQL Injection using parameterized queries.
* Included Stored Procedures for AddBook, UpdateBook, and DeleteBook.
* Implemented disconnected DataSet/DataTable management using SqlDataAdapter.
* Organized code cleanly with BookDataAccess.cs as a thin DAL service.
* Downgraded Sdk to .NET 8 console style to bypass the MSBuild comma-parsing bug on Web projects.
* Purged all bin/obj folders before final staging.
