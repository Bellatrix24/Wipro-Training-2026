# Day 28: jQuery AJAX Lifecycle & Dynamic Data Injections

This folder contains my daily learning notes and practicing lab scripts for Day 28. Our primary architectural focus was to build responsive user interfaces using jQuery's AJAX lifecycle engine, enabling targeted partial DOM changes.

---

## Dynamic Lookup System Directory Layout

In our decoupling labs, we mapped out a structural directory blueprint for our decoupled `StudentRegistration` dynamic lookup system. Organizing the files in separate concern segments ensures our system scales:

```text
StudentRegistrationLookup/
│
├── Controllers/
│   └── HomeController.cs           # Handles request routes and returns raw JsonResult payloads
│
├── Models/
│   └── Student.cs                 # Plain entity schema representation
│
└── Views/
    └── Home/
        └── StudentSearch.cshtml   # Contains form input fields and jQuery background AJAX pipelines
```

---

## Validation Search Cases Verified in Sandbox

During our testing execution run inside the sandbox environment, we verified two critical validation search behaviors:

1. **Fetching Valid Records to Update Visual Elements:**
   * **The Action:** The client dispatches a background request with a valid target student ID.
   * **The Outcome:** The server finds the database row and returns a `200 OK` JSON stream. The jQuery `.success` handler intercepts it and updates the targeted visual element (`#result`) cleanly with no window flashes or screen reloads.
2. **Handling Missing Indexes Gracefully with Clean Error Messages:**
   * **The Action:** The user inputs an ID that doesn't exist, or the backend connection drops.
   * **The Outcome:** The backend responds with a non-200 status (or the AJAX script enters the error pipeline). The `.error` handler captures this fallback event, updates the result container text cleanly in red to warn the user, and presents a non-disruptive alert dialogue.

---

## Practicing Assets

This folder houses our learning files:
* **[Ajax_Lifecycle_DeepDive_Notes.md](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-28-AJAX-Core-Demo/Ajax_Lifecycle_DeepDive_Notes.md)**: Conceptual guide comparing traditional full page lifecycle with AJAX partial updates, outlining the 8-phase execution path and key script security principles.
* **[DynamicUI_HomeController.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-28-AJAX-Core-Demo/DynamicUI_HomeController.cs)**: Standard MVC controller returning raw JSON payloads via custom endpoints.
* **[StudentSearch_Index.cshtml](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-28-AJAX-Core-Demo/StudentSearch_Index.cshtml)**: HTML and script workspace demonstrating button elements, response divs, CDN importing, and jQuery $.ajax implementations.

---

## Repository Tracking

Our dynamic lookup application files are saved directly in our centralized training repository:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
