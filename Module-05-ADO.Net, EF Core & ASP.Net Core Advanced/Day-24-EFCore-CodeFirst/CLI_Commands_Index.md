# Day 24: EF Core CLI Commands Reference Sheet

Hello! This is a quick, practical cheat-sheet mapping out the precise console keys we executed in the lab to bootstrap our project, install our drivers, and push database schema updates.

---

## 1. Project Initialization

To set up a fresh MVC template through our command-line interface, we use:

```bash
dotnet new mvc -n EFCoreDemo
```
* **What it does:** Spins up a clean Model-View-Controller project template inside a directory named `EFCoreDemo`. This sets up our controllers, views, and configuration pipelines automatically.

---

## 2. Nuget Package Installations

To use EF Core with Microsoft SQL Server, we must import two distinct packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
* **What it does:** Imports our dedicated SQL Server engine database drivers, allowing EF Core to speak the T-SQL dialect.

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
* **What it does:** Provisions our terminal with the required EF migration toolsets (like `dotnet ef`), enabling command line migrations and schema updates.

---

## 3. Database Migration Management

Once we define our C# model entities and DbContext bridge, we manage the schema updates using the following commands:

```bash
dotnet ef migrations add InitialCreate
```
* **What it does:** Directs EF Core to snapshot our current C# models and build our first schema step script (a migration script named `InitialCreate` under a new `Migrations` folder).

```bash
dotnet ef database update
```
* **What it does:** Executes our compiled C# migration scripts to sync changes live to SQL Server. It will automatically build the SQL tables, primary keys, and relations to match our code structures.
