# Day 22: Entity Framework Core (EF Core) Basics - Trainee Notes

Hello! This is my Wipro trainee study diary for Day 22. Today we transitioned from our low-level connected ADO.NET labs to learning about ORM (Object-Relational Mapping) tools, focusing on Entity Framework Core. Here is what we covered in our lectures and labs today!

---

## Understanding Object-Relational Mapping (ORM)

In plain English, an **ORM (Object-Relational Mapper)** acts like an automated translator map. 
* In our C# code, we think in terms of **Objects** (classes, lists, and properties).
* In SQL Server, the database engine thinks in terms of **Relational Tables** (rows, columns, and foreign keys).
* Normally, we would have to write hundreds of lines of raw SQL string commands to stitch these two worlds together. The ORM sits in the middle and automatically handles the translation, mapping our C# objects directly to SQL Server database tables.

---

## Main Benefits of Using an ORM

* **Saves Repetitive Code:** We don't have to write repetitive SQL queries (`INSERT`, `SELECT`, `UPDATE`, `DELETE`) or manually map fields from a `SqlDataReader` loop into C# objects.
* **Faster Development:** We can spend our time writing business logic in clean C# rather than wrestling with SQL query syntax.
* **Easier Schema Changes:** Database migrations are tracked in C#, making it much simpler to modify column schemas or add tables.
* **Automated Relationships:** The ORM handles relationships (one-to-many, many-to-many) and foreign key mappings behind the scenes without us writing manual SQL joins.

---

## Side-by-Side Comparison: ADO.NET vs. EF Core

Today we compared the traditional ADO.NET approach with EF Core. Here is my reference table:

| Aspect | ADO.NET | EF Core (ORM) |
| :--- | :--- | :--- |
| **Abstraction Level** | Low-level data access. | High-level data framework. |
| **Pipeline Management** | Manual (we must call `.Open()` and `.Close()`). | Automated (EF Core handles the pipeline lifetime). |
| **Queries** | Raw SQL text strings sent to database. | Write C# queries using LINQ (Language Integrated Query). |
| **Performance** | Blazing fast (direct execution with zero overhead). | Slightly slower due to background translation overhead. |
| **Developer Effort** | High (lots of boilerplate mapping code). | Low (C# classes map to database rows automatically). |

---

## Database Access Workflows

We learned that there are two primary paths when building applications with EF Core:

### 1. Code-First Approach
* **How it works:** We write our normal C# model classes first (specifying properties like `Name` and `Age`).
* Then, EF Core reads our C# code and automatically generates the matching SQL Server tables.
* If we change our C# models, we run standard command-line tools to update the database schema:
  ```bash
  dotnet ef migrations add AddStudentTable
  dotnet ef database update
  ```

### 2. Database-First Approach
* **How it works:** We start with a pre-existing SQL Server database containing pre-configured tables, constraints, and relationships.
* We then run a reverse-engineering command that tells EF Core to read the database schema and automatically generate the matching C# classes inside our project:
  ```bash
  dotnet ef dbcontext scaffold "ConnectionString" Microsoft.EntityFrameworkCore.SqlServer -o Models
  ```
