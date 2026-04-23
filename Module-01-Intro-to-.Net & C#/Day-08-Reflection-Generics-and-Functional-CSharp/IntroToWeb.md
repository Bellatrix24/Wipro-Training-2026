# Introduction to Web Development with .NET Core

## Client-Side vs. Server-Side
Understanding where the code runs is the first step in web development.

| Feature | Client-Side (Frontend) | Server-Side (Backend) |
| :--- | :--- | :--- |
| **Execution** | Runs in the user's Browser. | Runs on the Web Server. |
| **Technologies** | HTML, CSS, JavaScript. | C#, .NET Core, SQL Server. |
| **Role** | UI/UX, animations, input validation. | Database access, security, business logic. |
| **Visibility** | Code is visible to anyone (View Source). | Code is hidden and secure. |

---

## Razor Syntax Basics
Razor is a markup syntax that lets us embed C# code into HTML pages. It uses the `@` symbol to transition from HTML to C#.

### 1. Variables and Expressions
```html
<p>Current Time: @DateTime.Now</p>
<p>User Name: @Model.Name</p>
```

### 2. Control Structures
We can use loops and conditionals directly in our HTML:

**If Statement:**
```razor
@if (User.IsAuthenticated) {
    <p>Welcome back!</p>
} else {
    <p>Please log in.</p>
}
```

**For-Each Loop:**
```razor
<ul>
    @foreach (var student in Model.Students) {
        <li>@student.Name</li>
    }
</ul>
```

### 3. Code Blocks
For multiple lines of C# logic:
```razor
@{
    var greeting = "Hello Wipro!";
    var day = DateTime.Now.DayOfWeek;
}
<h2>@greeting</h2>
<p>Today is @day</p>
```

---

## Summary
Moving to Web means combining the power of **C# (Server-side)** with the interactivity of **JS (Client-side)**. Razor Syntax is the bridge that makes this possible in ASP.NET Core MVC applications.
