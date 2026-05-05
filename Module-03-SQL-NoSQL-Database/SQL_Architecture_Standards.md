# SQL and Microsoft SQL Server Architecture Standards

## Table Design Core Principles

Adherence to these five fundamental rules ensures schema scalability and data consistency within enterprise environments.

### 1. Primary Key Implementation
Every table must possess a unique identifier. Preference is given to surrogate keys (e.g., `INT IDENTITY` or `UNIQUEIDENTIFIER`) to decouple record identity from mutable business data.

### 2. Data Type Optimization
Selection of data types must align strictly with storage requirements.
- Use `INT` or `BIGINT` for numerical identifiers.
- Use `NVARCHAR` for internationalized text, specifying precise length constraints (e.g., `NVARCHAR(255)`) rather than defaults.
- Use `DECIMAL` for financial precision to avoid floating-point errors.

### 3. Data Integrity Constraints
Enforcement of integrity at the engine level:
- **NOT NULL**: Mandatory fields to prevent application-level null reference exceptions.
- **UNIQUE**: Preventing logical duplicates in candidate keys.
- **FOREIGN KEY**: Maintaining referential integrity across related entities.

### 4. Reserved Keyword Avoidance
Schema objects must not conflict with SQL Server reserved keywords (e.g., `SELECT`, `TABLE`, `USER`). All identifiers should be delimited using brackets `[]` if ambiguity exists, though descriptive naming is preferred.

### 5. Descriptive Schema Naming
Naming conventions must follow a standardized pattern:
- **PascalCase** for tables and columns.
- **Pluralization** for table names (e.g., `Employees`, `Transactions`).
- **Prefixing** constraints for clarity (e.g., `PK_`, `FK_`, `UQ_`).

## Verification via AAA Pattern

The **Arrange-Act-Assert (AAA)** pattern, established in application testing, is critical for database operation validation.

### Arrange
Establish the preconditions. This involves setting up the database state, populating lookup tables, and initiating a transaction.

### Act
Execute the specific SQL command or Stored Procedure under test. This is the primary operation whose side effects are being evaluated.

### Assert
Validate the outcome. Check for expected row counts, verified field values, or the presence of specific records. Crucially, the transaction is rolled back to maintain a clean environment.
