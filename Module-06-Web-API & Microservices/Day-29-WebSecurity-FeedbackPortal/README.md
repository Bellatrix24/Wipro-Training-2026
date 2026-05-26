# Day 29: Web Security, XSS Defense & Dynamic Encryption Basics

This folder contains my training notes and practicing code files for Day 29. Today's lab focus was on implementing input validation structures in ASP.NET Core, mitigating Cross-Site Scripting (XSS) issues in portals, and reviewing modern web data cryptography principles.

---

## Project Bootstrapping and Workspace Tree

To set up our secure portal in the lab, we instantiated a fresh project template via our command line:

```bash
dotnet new mvc -n FeedbackPortal
```

The resulting decoupled component files are organized inside our training directory as follows:

```text
FeedbackPortal/
│
├── Controllers/
│   └── FeedbackController.cs           # Processes inputs, enforces anti-forgery, redirects states
│
├── Models/
│   └── UserComment.cs                  # Enforces input schema validations via Data Annotations
│
└── Views/
    └── Feedback/
        ├── Create.cshtml              # Input submission form with jQuery Unobtrusive validations
        └── Success.cshtml             # Output card rendering data safely using HTML Encoding
```

---

## Security Verification Testing Routine

In today's verification sandbox, we tested our input filters and output sanitization defenses using two primary test scenarios:

### 1. Normal Input Submission
* **The Action:** We filled out the secure form using standard inputs (e.g., Name: `Parth`, Comment: `Great training session!`).
* **The Outcome:** The inputs successfully matched our regex patterns and schema sizes. The controller verified that `ModelState.IsValid` returned true and redirected cleanly to the success landing page.

### 2. Malicious Input Block (Defensive Script Injection Run)
* **The Action:** We attempted to execute a Cross-Site Scripting (XSS) attack. We filled out the Name field with `Amit <script>` or the Comment box with `<script>alert('Hacked!');</script>`.
* **The Outcome:**
  * If special script characters were placed in the Name field, the server-side regex check (`^[a-zA-Z\s]+$`) immediately failed. The controller caught this and re-rendered the form, presenting a red validation warning.
  * If script blocks bypassed validation and reached the display card, Razor view expression structures (`@Model.CommentText`) automatically executed output HTML encoding. The malicious script was converted to plain text (`&lt;script&gt;...`), displaying safely on the screen without running in the browser.

---

## Practice Assets

Our practice directory contains the following secure web assets:
* **[WebSecurity_And_Encryption_Notes.md](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-29-WebSecurity-FeedbackPortal/WebSecurity_And_Encryption_Notes.md)**: Daily study guide covering the three security golden rules, XSS mitigations, asymmetric vs. symmetric cryptography, and secret container best practices.
* **[FeedbackPortal_SourceCode.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-29-WebSecurity-FeedbackPortal/FeedbackPortal_SourceCode.cs)**: Unified C# file defining the `UserComment` data validation model and protective `FeedbackController`.
* **[Razor_Validation_Views.cshtml](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-29-WebSecurity-FeedbackPortal/Razor_Validation_Views.cshtml)**: Unified Razor markup file outlining our secure submission form (`Create.cshtml`) and auto-encoded success display card (`Success.cshtml`).

---

## Repository Tracking

Our training code is saved directly in our centralized git workspace:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
