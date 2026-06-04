# Day 40: Angular Workspace Layout and File Anatomy

Hey! Today's session was all about finding our way around a newly generated Angular project workspace. We broke down the file structure and practiced creating components and services using the CLI.

---

## 1. Anatomy of an Angular App

When we run `ng new AppName`, Angular scaffolds a complete project structure. It can look a bit overwhelming at first, so I made this cheat sheet table explaining the main directories and configuration files:

| Folder or File | What it is & Why it matters |
| :--- | :--- |
| **`src/`** | The root directory for our application source code. Almost all our coding happens inside this folder. |
| **`src/app/`** | The home folder for our custom building blocks. This is where we write our components, HTML templates, CSS styles, and business services. |
| **`src/assets/`** | A static assets folder. We use it to store images, local JSON mock datasets, icons, and fonts that the app needs to load. |
| **`styles.css`** | The global stylesheet. Any CSS rules written here apply to the entire application (great for global layouts, fonts, or color variables). |
| **`main.ts`** | The absolute entry point of the app. It bootstraps (starts) our root Angular module, acting a lot like a C# backend `Program.cs` file. |
| **`package.json`** | The project configuration file. It lists all NPM packages, dev dependencies, and contains terminal command scripts (like `start` or `build`). |
| **`angular.json`** | The workspace configuration configuration engine. It defines project build tasks, asset-tracking paths, and sets global builder options for dev and production. |

---

## 2. Trainee CLI Shortcut Index

Instead of building components, templates, and styles manually, the Angular CLI has built-in generators that wire everything up automatically. Here are the main shorthand commands we use:

1.  **Generate a Component:**
    Creates a folder containing the `.ts`, `.html`, `.css`, and `.spec.ts` files, and automatically registers the component in the closest module.
    ```bash
    # Long version: ng generate component my-component
    ng g c my-component
    ```
2.  **Generate a Service:**
    Creates a new service class and its test file. Services handle data fetching and shared logic.
    ```bash
    # Long version: ng generate service my-service
    ng g s my-service
    ```
3.  **Generate a Module:**
    Creates a new feature module boundary to encapsulate code.
    ```bash
    # Long version: ng generate module my-module
    ng g m my-module
    ```
