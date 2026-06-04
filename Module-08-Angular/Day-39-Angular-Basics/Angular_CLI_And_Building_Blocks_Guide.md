# Day 39: Angular CLI Commands and Building Blocks

Hey! Here is my reference cheat sheet for the Angular CLI (Command Line Interface) and the core architectural building blocks we learned about in the lab.

---

## 1. CLI Environment Checklist

To set up and run an Angular application locally, we use these standard terminal commands:

1.  **Global Installation:**
    Installs the Angular command line interface globally on our machine.
    ```bash
    npm install -g @angular/cli
    ```
2.  **Verify Versions:**
    Checks our current Angular CLI, Node.js, and OS versions to ensure compatibility.
    ```bash
    ng version
    ```
3.  **New Project Setup:**
    Scaffolds a new Angular application with standard directory structure, configurations, and dependencies.
    ```bash
    ng new WiproDemoApp
    ```
4.  **Local Hosting Server:**
    Builds the application in memory, runs a local development web server, and listens on port 4200.
    ```bash
    ng serve
    ```
    *   *Trainee Study Tip:* Use `ng serve --open` to automatically launch the app in your default browser at `http://localhost:4200/`.

---

## 2. Core Architectural Building Blocks

Angular organizes code using three main structural building blocks:

### Modules (`@NgModule`)
*   **What they are:** Cohesive containers for a block of application code dedicated to a specific domain or feature area.
*   **Key Metadata Fields:**
    *   `declarations`: The list of view components, directives, and pipes that belong to this module.
    *   `imports`: Other modules whose exported components are needed by templates in this module.
    *   `providers`: Creators of services that this module contributes to the dependency injection pool.
    *   `bootstrap`: The main application view (usually `AppComponent`) that Angular loads first.

### Components (`@Component`)
*   **What they are:** The basic UI building blocks of an Angular application. A component is composed of a TypeScript class (handles logic) and metadata selectors.
*   **Key Metadata Fields:**
    *   `selector`: The custom HTML tag name used to render this component (e.g., `<app-product-list>`).
    *   `templateUrl` / `template`: The HTML markup for the component.
    *   `styleUrls` / `styles`: The CSS files or inline styles applied specifically to this component.

### Templates
*   **What they are:** HTML structural pages that define what is rendered in the browser. 
*   **Key Features:**
    *   *Interpolation:* Double curly braces `{{ value }}` that dynamically pull variables from the TypeScript class to display on the page.
    *   *Directives:* Special HTML attributes (like `*ngIf` or `*ngFor`) that change DOM structures dynamically based on data states.
