# SQL Relational Design & Database Management

This guide covers fundamental concepts of relational database management systems (RDBMS), focusing on SQL commands, data relationships, and performance optimization.

## 1. DDL vs. DML

### Data Definition Language (DDL)
Used to define the database structure or schema.
- **CREATE**: To create objects in the database.
- **ALTER**: To modify the structure of the database.
- **DROP**: To delete objects from the database.
- **TRUNCATE**: To remove all records from a table, including all spaces allocated for the records.

### Data Manipulation Language (DML)
Used for managing data within schema objects.
- **SELECT**: To retrieve data from the database.
- **INSERT**: To insert data into a table.
- **UPDATE**: To update existing data within a table.
- **DELETE**: To delete records from a table.

---

## 2. SQL Joins

Joins are used to combine rows from two or more tables based on a related column between them.

| Join Type | Description |
| :--- | :--- |
| **Inner Join** | Returns records that have matching values in both tables. |
| **Left Join** | Returns all records from the left table, and the matched records from the right table. |
| **Right Join** | Returns all records from the right table, and the matched records from the left table. |
| **Full Join** | Returns all records when there is a match in either left or right table. |

---

## 3. Subqueries

A subquery is a query within another query. It is used to return data that will be used in the main query as a condition to further restrict the data to be retrieved.
- **Nested Subquery**: A subquery inside a WHERE clause.
- **Correlated Subquery**: A subquery that uses values from the outer query.

---

## 4. Performance Optimization: Indexing

Indexing is a powerful tool used to speed up the retrieval of data from a database table. An index creates an entry for each value that appears in the indexed column, allowing the database to find rows much faster than a full table scan.

- **Clustered Index**: Determines the physical order of data in a table. Only one per table.
- **Non-Clustered Index**: Does not sort the physical data; it creates a separate object that points back to the data.

---

## 5. Data Integrity: Transactions

A transaction is a sequence of operations performed as a single logical unit of work. Transactions must follow the **ACID** properties:
- **Atomicity**: All operations in the transaction succeed, or none do.
- **Consistency**: The database remains in a valid state before and after the transaction.
- **Isolation**: Concurrent transactions do not interfere with each other.
- **Durability**: Once a transaction is committed, it remains committed even in the event of a system failure.
