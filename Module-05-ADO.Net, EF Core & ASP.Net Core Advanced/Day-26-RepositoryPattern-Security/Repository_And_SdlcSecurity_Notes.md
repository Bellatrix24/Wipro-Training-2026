# Day 26: Repository Pattern Integration & SDLC Database Security

Hello! This is my personal trainee study guide for Day 26 of our engineering training. Today we discussed the architecture of the **Repository Design Pattern** for decoupled system models, learned how to integrate security habits into the Software Development Life Cycle (SDLC), and analyzed how relational database constraints protect referential integrity.

---

## The Repository Design Pattern Blueprint

In our labs today, we focused on separating our infrastructure data layer completely from our web controllers. 

### Why Decoupling Matters
In small projects, developers often write Entity Framework query calls directly inside controller endpoints. While this is fast to write initially, it causes major long-term issues:
* **Code Duplication:** The same query configurations get copy-pasted across different controller actions. If database schemas change, developers must hunt down and rewrite every single copy of the query.
* **Testing Complexity:** Controllers are hard-bound to a live SQL Server connection. We cannot test controller logic without running a live database server, which slows down automated unit test runs.

### The Solution
By using the **Repository Pattern**, we introduce an abstraction layer (an interface) between the controller and EF Core:
1. **Centralizes Query Configurations:** All database access logic is confined to a single repository class.
2. **Keeps Controllers Lightweight:** Web controllers only manage routing, validation, and view rendering. They have zero awareness of EF Core, DB connection strings, or ORMs.
3. **Supports Mocking for Test Routines:** We can easily spin up a fake (mock) repository class that returns a hardcoded list of C# objects in-memory. This allows our unit testing suite to validate controller behaviors in milliseconds without touching a physical database!

---

## Secure Database & SDLC Practices

Writing clean database structures is useless if data gets hijacked or modified in transit. Today, we listed the primary methods to protect relational databases throughout the SDLC:

* **Enforcing Transport Layer Security (TLS):** We must encrypt data in transit by appending secure properties to our connection parameters. This prevents attackers from executing "man-in-the-middle" eavesdropping scripts to sniff user credentials.
* **Column-Level Field Encryption:** Sensitive columns (like passwords, credit cards, or identity IDs) should be encrypted inside database disk files using built-in mechanisms like SQL Server *Always Encrypted*.
* **Early Security Risk Assessments:** Security should not be a checklist done at the end of the project. We perform *Threat Modeling* during the initial system design stages to analyze where data enters the app and identify potential attack surfaces early.
* **Peer-Driven Static Code Reviews:** Relentless code reviews by senior engineers catch common vulnerabilities (like unsanitized inputs, missing anti-forgery tags, and raw string query injections) long before they reach the main repository branch.

---

## Relational Integrity and Database Constraints

We spent the final section of our secure database lab focusing on structural security using database constraints, focusing on **Foreign Keys**:
* A **Foreign Key** is a database column on a child table that explicitly references a Primary Key column on a parent table.
* **Referential Integrity Protection:** The database engine blocks any action that breaks the relationship link. 
  * We cannot insert a record into the child table if its foreign key points to a non-existent parent.
  * We cannot delete a parent record if it still has active child records referencing it (unless configured for cascading deletes).
* **Trainee Reminder:** *Constraints ensure that child records never become orphaned or inconsistent, guaranteeing that our relational structure remains solid and logical.*
