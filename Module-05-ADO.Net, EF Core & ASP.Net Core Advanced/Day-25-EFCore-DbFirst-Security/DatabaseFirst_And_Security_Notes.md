# Day 25: Database-First Development & Web Security Fundamentals

Hello! This is my personal trainee learning guide for Day 25 of our backend training. Today we explored why large enterprise teams choose the Database-First workflow over Code-First, analyzed why older visual designers are no longer used, and summarized the core security concepts required to safeguard our web applications against cyber threats.

---

## Enterprise Database Design Workflows

We compared the design strategies we've learned over the last few days, looking at how architectural decisions affect collaboration and security.

### Why Large Applications Shift to Database-First
While Code-First is wonderful for small Greenfield apps, large companies running massive projects usually mandate the **Database-First** approach. Here is why:
1. **Messy Multi-Developer Branch Merges:** In large groups, if multiple developers make concurrent database changes, their C# migration snapshots become highly prone to merge conflicts, causing deployment issues.
2. **Risk of Structural Data Loss:** Code-First tools execute SQL update statements implicitly. A misconfigured migration running in production could drop columns or clear entire tables.
3. **DBA Layout Controls:** Database Administrators (DBAs) understand physical storage optimization (such as filegroups, partitions, clustered indexes, and locking behavior) far better than an ORM engine. Database-First allows DBAs to tune the database directly inside SQL Server first.
4. **Complex Legacy Integrations:** High-governance industries (like banking and insurance) operate databases built over decades. These databases contain pre-built triggers, sophisticated indexes, and enterprise-grade stored procedures that are near impossible to replicate from clean C# classes alone. Database-First reverse-engineers these existing catalogs instantly.

### Why Model-First is Obsolete
Older .NET systems allowed developers to design databases inside a graphic layout canvas in Visual Studio, saving them as `.edmx` files (Model-First). Today, visual canvas modeling is skipped:
* **Visual XML Merge Conflicts:** The graphic layouts are saved as massive, auto-generated XML files. Two developers modifying the visual diagram at the same time will cause nightmare merge conflicts in Git.
* **Failure to Scale:** Drawing diagrams with hundreds of tables on a canvas becomes extremely slow and impossible to read.
* **No Tool Support:** Modern .NET runtimes (like .NET Core and .NET 8) do not support `.edmx` visual canvas tools, focusing entirely on Code-First and Database-First.

---

## Summary of Core Web Security Concepts

Writing solid C# logic doesn't matter if our application gets hacked on day one. We studied four major web security pillars:

### Protecting Against SQL Injection
* **The Attack:** A hacker inputs malicious SQL commands inside standard form input fields. If the application stitches strings together to make a query, the SQL engine executes those commands, leaking sensitive data or dropping tables.
* **The Shield:** Prevented completely by using parameterized inputs (which treat inputs purely as literal data values rather than executable code) or by running standard Entity Framework Core LINQ queries, which parameterize inputs automatically in the background.

### Mitigating Cross-Site Scripting (XSS)
* **The Attack:** Hackers inject malicious JavaScript scripts inside input text boxes. If the web server saves this script and prints it onto other users' browsers, the script executes, stealing cookies, session keys, or redirecting pages.
* **The Shield:** Blocked via thorough input validation (using regex filters or sanitization libraries) and explicit **output encoding** (HTML encoding dynamic values before injecting them into the browser DOM so script tags render as plain text).

### Defending Against Cross-Site Request Forgery (CSRF)
* **The Attack:** A victim logged into a secure banking app visits a malicious site. The malicious site runs a background script that posts a transaction form to the secure bank, hijacking the logged-in session cookies to steal funds.
* **The Shield:** Stopped by generating and injecting unique **Anti-Forgery Tokens** inside all our HTML post forms. The backend controller verifies this token before processing any state changes, discarding requests made from external domains.

### Authentication vs. Authorization
* **Authentication (AuthN):** Verifies **who** the user is. (e.g., verifying a password or checking a secure session cookie).
* **Authorization (AuthZ):** Verifies **what** permissions or roles that authenticated user has. (e.g., verifying if the user belongs to the "Admin" role or has the "CanDeleteProduct" claim). 
  * **Role-Based Access Control (RBAC):** Restricts access based on broad group folders (e.g., `[Authorize(Roles = "Manager")]`).
  * **Claims-Based Access Control:** Restricts access based on individual descriptive traits (e.g., checking if the user has an ID badge claim or age claim).
