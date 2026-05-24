# ASP.NET Core Assignment: Razor Pages & MVC

This solution represents a professional student submission for Module 04 (ASP.NET Core Razor Pages & MVC) of the Wipro 2026 Training curriculum. It contains two distinct web application projects inside a single consolidated solution, showcasing fundamental and advanced web development techniques in C# and .NET.

---

## 📂 Project Structure

* **RazorPagesAssignment**: An advanced Razor Pages application focused on complex model binding, dynamic route mapping, and partial view reuse.
* **MVCAssignment**: A Model-View-Controller application demonstrating strict separation of concerns, nested complex model binding, and form validation pipelines.

---

## 🚀 Implemented Features

### Part 1: Advanced Razor Pages Implementation (RazorPagesAssignment)
* **In-Memory Store**: Uses static lists in `ProductStore.cs` to manage catalog data dynamically without database dependencies.
* **Complex Data Models**: Demonstrates a `Product` model containing simple values and a nested list of `Category` tags.
* **Reusable Layout Component**: Implements a dedicated `_ProductSummary.cshtml` partial view to render standardized card items in the catalog list.
* **Complex Model Binding**: Leverages checkbox arrays bound to selected lists (`SelectedCategoryIds`) to dynamically tag categories during new product additions.
* **Custom Route Mapping**: Registers a dynamic custom route (`/Products/{id}`) in the details view for highly clean and user-friendly URL paths.

### Part 2: MVC Pattern and Model Binding (MVCAssignment)
* **Rigorous Separation of Concerns**: Clearly segregates data schemas (`Models`), Razor template views (`Views`), and controller pipelines (`Controllers/UserController`).
* **Nested Model Binding**: Renders and validates simple field bindings alongside nested object structures using a complex `User` model composed of an inner `Address` class.
* **Validation Attributes**: Adds native C# validation controls (`[Required]`, `[StringLength]`, `[Range]`, and `[RegularExpression]`) with user-friendly custom error displays.
* **Redirection Control**: Uses standard Post-Redirect-Get pattern to map form submissions cleanly to a results visualization page (`/User/Result`).

---

## 💻 How to Run the Projects

Ensure you have the .NET SDK installed (minimum version .NET 8).

### Step 1: Open Terminal
Open a command prompt or PowerShell terminal and navigate to the project directory:
```bash
cd Wipro-Training-2026/Module-04-Asp.NetCore-RazorPages-MVC/Day-16-WebAPI-Middleware/RazorMVCApp
```

### Step 2: Build the Solution
Compile both projects to ensure there are no errors:
```bash
dotnet build
```

### Step 3: Run the Razor Pages Project
Run the project and look at the output to see the localhost port (typically http://localhost:5000 or similar):
```bash
dotnet run --project RazorPagesAssignment
```

### Step 4: Run the MVC Project
Run the project on a separate terminal or after stopping the previous run:
```bash
dotnet run --project MVCAssignment
```

---

## 🎯 Testing and Routes Checklist

### Razor Pages Test Routes
* **Home Page**: `http://localhost:<port>/` - Introduces the trainee portfolio.
* **Products Catalog**: `http://localhost:<port>/Products` - Renders current products.
* **Add New Product**: `http://localhost:<port>/Products/Create` - Enter catalog details and select checkboxes to tag multiple categories.
* **Product Details**: `http://localhost:<port>/Products/101` - Test dynamic routing paths using custom routes.

### MVC Test Routes
* **Home Page**: `http://localhost:<port>/` - Introduces the MVC binding architecture.
* **Registration Form**: `http://localhost:<port>/User/Create` - Submit name, age, and nested address values.
* **Submission Details**: `http://localhost:<port>/User/Result` - Confirms bound and validated user and address records.
