# Day 17: Razor Pages Binding & Web Templates

## Daily Summary
Today's focus was understanding how ASP.NET Core project templates are set up, and learning how data moves bi-directionally between our user interface input boxes and our backend C# fields. 

This bi-directional flow is handled automatically by a feature called **Model Binding**. When a user types into an input box on a web page and hits submit, Model Binding grabs that text and matches it directly to a C# property decorated with `[BindProperty]`. Likewise, when we want to display data from the server, C# matches the properties back to the HTML template so the browser can show it. It prevents us from having to write long, messy request-parsing code by hand!

---

## File Contents in this Folder

*   [Web_Templates_And_Binding.md](./Web_Templates_And_Binding.md): A study guide written in plain English explaining project templates (Razor Pages, MVC, Web API), the page lifecycle (`OnGet` vs `OnPost`), property binding, layered architectures, and the purpose of validation.
*   [SimpleBinding_Index.cshtml.cs](./SimpleBinding_Index.cshtml.cs): A clean C# backend code-behind class inheriting from `PageModel` to demonstrate how standard form inputs and URL query strings are bound directly to C# variables.

---

## Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 04 (ASP.NET Core Web Applications)
*   **Target Scope**: Day 17 - Razor Pages Binding & Web Templates
