# Day 24: EF Core Code-First Workflow & CLI Tools - Trainee Notes

Hello! This is my personal trainee study log for Day 24 of our engineering training. Today we focused on the step-by-step lifecycle of the Entity Framework Core **Code-First** approach, learning how to bootstrap our models and synchronize them directly with SQL Server using command line tools.

---

## Core Data Access Approaches

In modern application engineering, we have three distinct workflows for building databases and application code:

### Code-First Approach
* **How it works:** The developer builds C# model classes first (standard object models containing properties like `Id`, `Name`, and `Age`). The database schema and its internal context rules are spun up automatically via command line migrations.
* **Who it's for:** Perfect for Agile software groups running domain-driven pipelines. Since developers spend 100% of their time inside C# code, there's no need to context-switch between C# and SQL Server Management Studio. EF Core manages the SQL generation for us.

### Database-First Approach
* **How it works:** We start with a pre-existing live SQL Server database (e.g., in legacy environments with strict DBA-led structures). The framework automatically reverse-engineers all C# classes and context rules directly from those pre-existing live SQL tables.
* **Who it's for:** Great for legacy enterprise apps with strict DB governance rules where developers are not permitted to change schema structures directly from the application side.

### Model-First Approach
* **How it works:** Developers create data structures visually inside a graphic layout canvas in Visual Studio (using `.edmx` files), then automatically generate both the C# classes and the SQL tables from these visual diagrams.
* **Who it's for:** Rarely used in modern systems due to low design flexibility, visual tool bugs, and lack of support in EF Core (only supported in older Entity Framework versions).

---

## EF Core vs. ADO.NET in Enterprise Projects

In our training today, we analyzed why modern enterprise teams heavily prefer EF Core for large-scale portfolios over traditional low-level ADO.NET pipelines:

| Feature / Capability | ADO.NET | EF Core (ORM) |
| :--- | :--- | :--- |
| **Development Speed** | Slow (requires writing custom SQL strings and custom reader-to-object loops for every entity). | Fast (C# models map automatically; CRUD tasks are handled with single method calls). |
| **Type Safety** | Low (queries are plain text strings; typos in column names only crash at runtime). | High (uses LINQ queries; compile-time checks catch syntax errors instantly). |
| **State Tracking** | Manual (developers must track which entities are new, modified, or deleted). | Automatic (the DbContext change tracker tracks entity changes in the background). |
| **Database Portability** | Low (SQL queries are usually highly dialect-specific to SQL Server or Oracle). | High (database providers abstract the query language; switching databases is simple). |
| **Migrations & Version Control** | Manual (DBAs or developers must write SQL update scripts and coordinate versions manually). | Automated (migration scripts are generated in C# and tracked in git along with the code). |

### Trainee Summary:
While **ADO.NET** remains preferred for hyper-specific raw bulk scripts (like writing a custom high-performance data loader processing millions of rows at once), **EF Core** dominates enterprise portfolios due to strongly typed LINQ layers, automatic relationship tracking, and automated version-controlled database migrations.
