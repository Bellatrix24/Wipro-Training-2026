# Customer Feedback and User Registration Portal

This project represents a professional student submission for Module 04 (ASP.NET Core Razor Pages & MVC) of the Wipro 2026 Training curriculum, specifically focusing on form state, HTML Helper extensions, custom TagHelpers, and robust validation pipelines.

---

## 📂 Implemented Features

### Customer Feedback Portal
* **Strongly Bound Forms**: Capture Name, Email, Rating, and Comments via C# models.
* **HTML Helpers**: Incorporate `Html.TextBoxFor`, `Html.TextAreaFor`, and `Html.DropDownListFor` to render inputs.
* **Custom Rating Star TagHelper**: Implemented in `RatingStarsTagHelper.cs` to render dynamic yellow star symbols (`★`, `☆`).
* **Custom Input HTML Helper**: Registered as an extension `CustomInput` for `IHtmlHelper` inside `CustomInputHtmlHelper.cs` to generate custom CSS styled inputs.
* **Submitted Submissions Viewer**: Renders dynamic inputs saved to static stores using looping structures.

### Registration and Validation System
* **Data Annotations Validation**: Guards user registrations (`UserRegistration.cs`) with standard email, required, and length validators.
* **Custom Matching Validator**: Implements a custom class attribute `[PasswordMatch]` in `PasswordMatchAttribute.cs` to ensure password entries match.
* **Validation Summary Dashboard**: Displays validation summary groups alongside precise inline field warnings.
* **Active Client-Side Validation**: Integrates client-side jQuery and unobtrusive validation script libraries.

---

## 💻 How to Run the App

Ensure you have the .NET SDK installed (minimum version .NET 8).

### Step 1: Open Terminal
Navigate to the project root directory:
```bash
cd Wipro-Training-2026/Module-04-Asp.NetCore-RazorPages-MVC/Day-18-State-Binding-Validation/FeedbackValidationApp
```

### Step 2: Build the Solution
Compile the projects:
```bash
dotnet build
```

### Step 3: Run the Application
Launch the web server:
```bash
dotnet run --project FeedbackValidationApp
```

---

## 🎯 Testing and Routes Checklist

### Support Routes
* **Home Page**: `http://localhost:<port>/` - Landing dashboard.
* **Feedback Form**: `http://localhost:<port>/Feedback/Create` - Submit feedback entries using custom Star TagHelper and HTML Helper.
* **Feedback List**: `http://localhost:<port>/Feedback/List` - Displays in-memory submissions.
* **User Registration**: `http://localhost:<port>/Registration/Create` - Tests client and server-side model validation.
* **Success Dashboard**: `http://localhost:<port>/Registration/Success` - Shows registration success.

---

## 📋 Trainee Submissions Info
* **In-Memory Lists**: All customer entries are saved to a static runtime store `FeedbackStore.cs` in memory and will reset once the app restarts.
* **Git Hygiene**: Active build output files (`bin/`, `obj/`) are filtered out by the `.gitignore` configuration.
