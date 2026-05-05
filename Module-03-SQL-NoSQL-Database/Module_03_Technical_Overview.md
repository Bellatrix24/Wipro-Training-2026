# SQL, NoSQL, and Microsoft SQL Server Technical Overview

## Application Logic to Persistent Storage Transition

The shift from transient in-memory C# application logic to persistent storage requires a robust architectural transition. While application code manages state during execution, Data Persistence ensures state longevity across process lifecycles. This module bridges the gap between object-oriented models and relational schemas, focusing on the Relational Database Management System (RDBMS) as the primary authority for data integrity and durability.

## Core Technical Focus Areas

### SQL Fundamentals: Structural and Manipulative Operations
Execution of **Data Definition Language (DDL)** and **Data Manipulation Language (DML)** forms the baseline for database interaction.
- **DDL**: Defining schemas, tables, and constraints to enforce structural integrity.
- **DML**: Standardized operations for data retrieval, insertion, modification, and deletion.

### Advanced Querying: Relational Joins and Optimization
Complex data retrieval involves the orchestration of multiple entities. This section covers:
- **Inner, Left, Right, and Full Outer Joins**: Logical mapping of disparate datasets.
- **Query Execution Plans**: Analysis of indexing strategies and performance bottlenecks.

### Microsoft SQL Server Architecture
Utilization of Microsoft SQL Server for mission-critical persistence.
- **T-SQL Programming**: Implementing logic via Stored Procedures, Functions, and Triggers.
- **Buffer Management**: Understanding how the SQL Server engine manages data in memory vs. disk.

### NoSQL Systems and Data Modeling
Transitioning to non-relational storage for specific use cases (e.g., MongoDB, Cosmos DB).
- **Schema-on-Read**: Managing unstructured or semi-structured data (JSON/BSON).
- **CAP Theorem**: Evaluating the trade-offs between Consistency, Availability, and Partition Tolerance.

## Core Persistence Workflows

### Database Verification and Testing (Day 11)
Implementation of testing frameworks to validate persistence logic. Focus on integration testing with SQL Server and ensuring transactional atomicity during test execution.

### Schema Architecture and Design Patterns (Day 12)
Application of SOLID principles to relational design to ensure scalability and maintainability.
- **Single Responsibility**: Ensuring tables represent unique business entities.
- **Dependency Inversion**: Decoupling the application from specific database implementations through abstraction layers.
- **Normalization**: Reducing redundancy while maintaining high performance (1NF to 3NF).
