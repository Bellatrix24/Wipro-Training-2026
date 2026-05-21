# Day 19: Routing Patterns & Session Tracking

## Daily Summary
Today's focus was learning how our web application handles incoming web request URLs (Routing) and how we can remember logged-in user details securely on the server (Session Management). 

We explored three routing variations (conventional, custom named, and attribute routing) to map URL layouts. We also implemented session-state storage mechanisms to securely track user sessions using client-side cookie identifiers, bypassing the stateless limitations of HTTP.

---

## File Contents in this Folder

*   [Routing_And_Sessions_Notes.md](./Routing_And_Sessions_Notes.md): A study guide written in plain English explaining network ports, advanced validation types, routing pattern variations, and session mechanics.
*   [FoodDelivery_RestaurantController.cs](./FoodDelivery_RestaurantController.cs): A clean MVC controller demonstrating how custom attribute routing is configured to map custom URLs (like `/restaurant/our-menu` and dynamic integer IDs).
*   [StudentAuth_AccountController.cs](./StudentAuth_AccountController.cs): A neat, simple session tracking controller showing how to set and read string values inside `HttpContext.Session` for user logins and dashboard displays.

---

## Lab Test Scenarios

To confirm that today's routing patterns and session state mechanics function properly, we verified two test flows in our training system:

1.  **Scenario 1: Dynamic Menus via Custom Attribute URLs**
    *   *Result*: Accessing `/restaurant/our-menu` successfully bypassed fallback routing pipelines and loaded the custom menu string content. Fetching `/restaurant/details/5` correctly extracted the integer variable and displayed `"Showing details for restaurant number: 5"`.
2.  **Scenario 2: Active User Dashboards using Sessions**
    *   *Result*: When submitting a username to our login action, the server saved the string inside the `HttpContext.Session` state. Upon redirection to the dashboard action, the server read the session value and passed it to `ViewBag.User`, outputting a greeting message indicating the user is logged in.

---

## Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 04 (ASP.NET Core Web Applications)
*   **Target Scope**: Day 19 - Advanced Validations, Routing, and Session Management
