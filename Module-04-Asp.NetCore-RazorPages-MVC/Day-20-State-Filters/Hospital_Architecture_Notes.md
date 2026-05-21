# Study Notes: Web State Management and MVC Filters

Today's training focused on choosing the right state management strategies for a hospital software scenario (MediCare Plus) and learning how to intercept the MVC request pipeline using Filters. Here are my daily notes and lab summaries.

---

### Medicare Plus State Management Strategy

In a secure hospital application, managing patient data across different page requests is critical. We mapped out a dual-layer strategy using cookies and sessions to fix our workflow issues:

| Where it Lives | Tool Name | Specific Variables Tracked | Why We Use It Here |
| :--- | :--- | :--- | :--- |
| **Client-Side** (Browser) | **Cookies** | `PatientEmail`, `PreferredLanguage`, `LastLoginDate` | Used for persistent data that drives "Remember Me" automated checkboxes or saving local UI preferences. These persist even if the browser closes. |
| **Server-Side** (Server RAM) | **Sessions** | `PatientID`, `SelectedDoctor`, `AppointmentTime` | Critical for secure, temporary transactional data. We track active booking states across screens before final database confirmation without exposing raw patient IDs to browser cookies. |

---

### The MVC Filter Paradigm

An MVC **Filter** is a special block of code that intercepts requests before or after an action method runs. They let us write common, cross-cutting routines (like logging or security checks) once and apply them globally instead of copying code into every single controller.

Here are the three standard filters we explored in our workshop:

1.  **Authorization Filters**:
    *   *Purpose*: This runs at the very beginning of the filter pipeline. It validates authentication credentials to ensure the requester is allowed to view the page.
    *   *Hospital Use Case*: Restricting access to clinical notes so only logged-in doctors or verified nurse accounts can view private patient medical history reports.
2.  **Action Filters**:
    *   *Purpose*: Intercepts the request immediately before and after an action method executes.
    *   *Hospital Use Case*: Automatically calculating request execution timelines and printing audit logs to track administrator actions in compliance tracking files.
3.  **Exception Filters**:
    *   *Purpose*: Runs only if an action method encounters an unhandled application crash or failure.
    *   *Hospital Use Case*: Intercepting runtime database connection drops globally to log the error privately for engineers while redirecting hospital users to a friendly, safe error screen (rather than exposing raw technical code traces).
