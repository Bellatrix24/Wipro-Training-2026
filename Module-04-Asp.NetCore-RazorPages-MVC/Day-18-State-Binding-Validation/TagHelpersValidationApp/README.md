# Customer Feedback and User Registration Portal

This project represents a professional student submission for Module 04 (ASP.NET Core Razor Pages & MVC) of the Wipro 2026 Training curriculum, specifically focusing on custom TagHelpers, extension HTML Helpers, in-memory stores, and model validation constraints.

---

## Implemented Features

### Customer Feedback Portal
* **Structured Feedback Form**: Enforces input tagging for Name, Email, Rating, and Comments.
* **HTML Helpers**: Integrates standard `Html.TextBoxFor`, `Html.TextAreaFor`, and `Html.DropDownListFor` methods.
* **Custom Rating Star TagHelper**: Implemented in `RatingStarsTagHelper.cs` using Unicode HTML star entities (`&#9733;`, `&#9734;`) without using raw emojis.
* **Custom Input HTML Helper**: Registered as `CustomInput` for `IHtmlHelper` to allow custom styled input generation.
* **Submission Records list**: Displays entries from static runtime collections.

### Registration and Validation System
* **Strong Validation Constraints**: Configured validation attributes inside the `UserRegistration.cs` model.
* **Custom Compare Attribute**: Leverages custom class-level attribute `[PasswordMatch]` in `PasswordMatchAttribute.cs` to verify matching passwords.
* **Error Summary Dashboard**: Renders registration validation summary boxes and inline validation message spans.
* **Client-Side Verification**: Runs active client-side script validation in the browser.

---

## How to Run the App

Ensure you have the .NET SDK installed (minimum version .NET 8).

### Step 1: Open Terminal
Navigate to the project root directory:
```bash
cd Wipro-Training-2026/Module-04-Asp.NetCore-RazorPages-MVC/Day-18-State-Binding-Validation/TagHelpersValidationApp
```

### Step 2: Build the Solution
Compile the projects:
```bash
dotnet build
```

### Step 3: Run the Application
Launch the web server:
```bash
dotnet run --project TagHelpersValidationApp
```

---

## Testing and Routes Checklist

### Support Routes
* **Home Page**: `http://localhost:<port>/` - Landing dashboard.
* **Feedback Form**: `http://localhost:<port>/Feedback/Create` - Form showing custom Star TagHelper and HTML Helper.
* **Feedback List**: `http://localhost:<port>/Feedback/List` - Renders submitted feedbacks.
* **User Registration**: `http://localhost:<port>/Registration/Create` - Form illustrating summary and inline model validation.
* **Success Dashboard**: `http://localhost:<port>/Registration/Success` - Shows registration success.

---

## 📋 Trainee Submissions Info
* **In-Memory Lists**: All user entries are saved to a static runtime store `FeedbackStore.cs` in memory and will reset once the app process terminates.
* **Git Hygiene**: Active build output files (`bin/`, `obj/`) are filtered out by the `.gitignore` configuration.
