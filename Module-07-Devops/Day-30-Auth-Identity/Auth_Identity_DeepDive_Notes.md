# Day 30: Authentication, Authorization, and Session Security

Hey! Here are my study notes from today's class. I've broken down how we secure ASP.NET Core apps using authentication, authorization, and some essential session-hardening settings.

---

## 1. Authentication vs. Authorization (The Two Pillars)

It's super easy to get these two mixed up, but today's lecture made it really clear:

*   **Authentication (AuthN):** "Who are you?"
    *   This is the first step where the user proves their identity (like showing an ID card or logging in with a username and password).
    *   **Common mechanisms:**
        *   *Cookie Authentication:* The server drops a cookie in the user's browser, and the browser sends it back on every request to show "Hey, it's still me!"
        *   *JWT (JSON Web Tokens):* Often used in APIs. A signed token is sent in the header of each request.
*   **Authorization (AuthZ):** "What are you allowed to do?"
    *   This happens *after* we know who the user is. The app looks at their access permissions and decides if they can access a specific page or execute a certain action.
    *   *Analogy:* Getting into the concert building is Authentication (you have a ticket). Getting into the VIP backstage area is Authorization (your ticket has a "VIP" badge).

---

## 2. Types of Authorization Strategies

We played around with two different ways to lock down features in our lab:

### Role-Based Authorization
*   **What it is:** Access is granted based on broad, structural groups or departments the user belongs to.
*   **How we use it:** We decorate controllers or actions with roles.
    *   *Example:* `[Authorize(Roles = "Admin, Manager")]`
*   **Student Reminder:** This is great for high-level divisions, like separating general users from administrators or content editors.

### Claims-Based Authorization
*   **What it is:** Access is fine-tuned based on specific traits, key-value pairs, or attributes printed on the user's identity card (known as "Claims").
*   **How we use it:** Instead of just checking a role, we check if they have a specific claim (like `EmployeeNumber`, `ClearanceLevel`, or `DateOfBirth`).
    *   *Example:* Checking if the user has an `EmployeeNumber` claim, or if their `ClearanceLevel` claim matches "Level5".
*   **Student Reminder:** This is way more flexible than roles because a claim can represent literally any piece of information about the user.

---

## 3. Secure Session Management

If we're storing user state or session data on the server, we have to make sure hackers can't hijack the session cookie. Here are the core security options we must configure:

1.  **HttpOnly:**
    *   **What it does:** Prevents client-side scripts (like JavaScript) from reading or accessing the cookie.
    *   **Why it matters:** If a hacker tries an XSS (Cross-Site Scripting) attack, they can't steal our session cookie via `document.cookie`.
2.  **SecurePolicy (Secure Cookies):**
    *   **What it does:** Forces the browser to send the cookie *only* over encrypted HTTPS connections.
    *   **Why it matters:** Stops network sniffers on public Wi-Fi from reading our session ID in plain text.
3.  **SameSite:**
    *   **What it does:** Controls whether cookies are sent with cross-site requests.
    *   **Why it matters:** Setting it to `Lax` or `Strict` helps block CSRF (Cross-Site Request Forgery) attacks.
