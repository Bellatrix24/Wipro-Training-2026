# Day 20: Filters & State Management

## Daily Summary
Today's focus was understanding how to write secure and scalable web applications by combining data state persistence layers with MVC pipeline interception filters. 

In a complex enterprise system (like a hospital environment), we need distinct approaches to manage data scope and security:
*   **Cookies**: Used to persistent-store client preferences directly in the browser across tab closures.
*   **Sessions**: Used to secure temporary transaction variables safely inside the server RAM.
*   **Pipeline Filters**: Overriding action methods globally to apply cross-cutting security, monitoring, and audit log steps in one centralized layout rather than duplicating code across multiple controllers.

---

## File Contents in this Folder

*   [Hospital_Architecture_Notes.md](./Hospital_Architecture_Notes.md): A study guide detailing our Medicare Plus state management strategies (scope division between sessions and cookies) and explaining built-in filter varieties (Authorization, Action, and Exception Filters).
*   [HospitalState_AccountController.cs](./HospitalState_AccountController.cs): A clean MVC controller script showcasing how to write active usernames to server-side Session state, append custom language cookies using `CookieOptions` and `Response.Cookies.Append`, and read request values back securely.
*   [ActivityLogFilter.cs](./ActivityLogFilter.cs): A custom action filter class inheriting from `ActionFilterAttribute` that overrides pipeline methods to output trace status alerts during action execution lifecycles.

---

## Design Paths Mapped Out

During our architectural state and security workshop, we established three key design practices:

1.  **Managing Session Context Buffers**
    *   *Approach*: Storing private identifiers (like patient ID, chosen doctors, and tentative booking times) safely inside server sessions. This isolates private patient details from browser-level tampering.
2.  **Configuring Global Interception Traps**
    *   *Approach*: Setting up action filter overrides to run common auditing logs and processing footprint calculations. This acts as a centralized gatekeeper that automatically monitors action execution pipelines.
3.  **Separating Tracking Data Scopes**
    *   *Approach*: Keeping lightweight persistent UI selections (like emails, language selections, and last login dates) in local cookies, while allocating critical transaction contexts exclusively to server session state buffers.

---

## Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 04 (ASP.NET Core Web Applications)
*   **Target Scope**: Day 20 - Web State Management and Interception Filters
