# Day 22: Entity Framework Core (EF Core) Introduction

This folder contains my training notes and Code-First model files for Day 22. Today we moved away from managing low-level SQL database connections manually, entering the world of automated Object-Relational Mappers (ORMs) using EF Core.

---

## Overview of Daily Learning

Today's training marked a major transition in our backend database integration capabilities. We studied:
1. **Object-Relational Mapping (ORM)**: What it is, why it exists, and how it dramatically reduces manual database mapping overhead.
2. **ADO.NET vs. EF Core**: Exploring the trade-offs between low-level raw execution and high-level C# abstractions.
3. **Database Integration Workflows**: Learning how Code-First and Database-First methodologies allow us to sync our codebases and databases in either direction.

---

## Transitioning from ADO.NET to Entity Framework Core

In our previous lab, we manually configured connection pipelines, constructed SQL query command strings, opened the pipeline, streamed rows via a `SqlDataReader`, and closed everything in structured blocks.

Today, we saw how EF Core replaces this boiler-plate logic:
* Instead of mapping SQL columns to C# properties manually, we write a standard C# model representation like [CodeFirstDemo_Models.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-22-EFCore-Intro/CodeFirstDemo_Models.cs).
* EF Core takes over connection pool management, safely opening and closing database sessions on the fly.
* Rather than stitching string-based queries, we write standard LINQ expressions that compile and get translated to optimized SQL statements in the background.

---

## Lab Components

We verified today's concepts with two main assets:
* **[EFCore_ORM_Notes.md](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-22-EFCore-Intro/EFCore_ORM_Notes.md)**: A complete study summary explaining ORM basics, listing core advantages, side-by-side comparison tables, and detailing Code-First and Database-First approaches.
* **[CodeFirstDemo_Models.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-22-EFCore-Intro/CodeFirstDemo_Models.cs)**: A C# implementation defining a `Student` model utilizing data annotations (`[Key]` and `[Required]`) along with a customized `CollegeDbContext` context mapper configured to connect to SQL Server.

---

## Repository Tracking

Our daily progress is tracked within our training workspace:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
