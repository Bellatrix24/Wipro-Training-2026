# EduLearn Course Management SPA Assignment

Welcome to my submission for the EduLearn Course Management Single-Page Application (SPA) assignment! This project demonstrates core Angular component-to-component data transmission, lifecycle flows, and two-way forms data-binding mechanisms.

---

## 1. Technical Rationale: Frameworks vs. DOM Scripting

Instead of utilizing manual, fragile JavaScript DOM manipulation scripts (which break easily when HTML structural nodes change and require slow, manual updates), we choose Angular's structured component tree architecture. 
*   This ensures data flows dynamically and updates views automatically.
*   By separating the view (HTML templates) from the logic (TypeScript controllers), the application remains easy to test, modular, and SOLID-compliant.

---

## 2. Setup Guidance Checklist

To compile, load dependencies, and run this SPA assignment locally, use these standard terminal commands:

1.  **Install Node Modules:**
    Downloads all required Angular framework and package dependencies based on `package.json`.
    ```bash
    npm install
    ```
2.  **Launch Local Development Server:**
    Builds the application in memory and hosts the web server on default port `4200`.
    ```bash
    ng serve
    ```
3.  **Access the Application:**
    Open your browser and navigate to `http://localhost:4200/` to test course listings and details.

---

## 3. Data-Binding Breakdowns

This assignment applies three core Angular data-binding strategies to synchronize course details:

*   **Property Binding (`[course]="selectedCourse"`):**
    Bridges the communication gap between components. It flows the currently highlighted course object down from the parent `CourseListComponent` to the child `CourseDetailComponent`.
*   **Event Binding (`(click)="selectCourse(course)"`):**
    Intercepts user button clicks on the listing page. It calls our select action method to instantly switch the active memory context of our course variables.
*   **Two-Way Binding (`[(ngModel)]="course.title"`):**
    Fully synchronizes the child template text input field with the underlying object's title property. Any edit typed inside the text box updates the title immediately in the parent listing array without needing database re-queries or browser page refreshes.

---

## 4. Future Scope: Book Store Management System Roadmap

For the upcoming *Online Book Store Management System* project, we plan to extend these foundational concepts as follows:
*   **Custom Services:** Move hardcoded mock data lists to custom injectable services (`BookService`) that use `HttpClient` to communicate with backend databases.
*   **Reactive Validation Rules:** Incorporate forms validation rules to handle client checkout fields, blocking invalid orders at the frontend.
*   **Persistent Storage State:** Save active cart contexts inside the browser's `localStorage` to preserve selections across page reloads.

---

## 5. Directory Layout Check

Here is the file layout of this Course Management SPA assignment folder:

```
Module-08-Angular/
└── Module-08-Assignments/
    └── Course-Management-SPA/
        ├── README.md
        ├── course-list.component.ts
        ├── course-list.component.html
        ├── course-detail.component.ts
        └── course-detail.component.html
```

---

## 6. Repository Tracking
*   Project Repository: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
