# Day 44: SDLC Productivity & Copilot Workflows

## IDE Acceleration Vectors

GitHub Copilot acts as an inline pair programmer. Below is a breakdown of how I use it inside Visual Studio to speed up daily coding tasks:

| Feature / Tool | Mechanics | Trainee Integration Use Case |
| :--- | :--- | :--- |
| **Ghost Text Autocomplete** | Inline gray text suggestions that appear as you write code. Press `Tab` to accept. | Speeds up boilerplate writing like property declarations, simple lists, or standard loops. |
| **Context-Aware Comment Logic** | Writing a descriptive comment (e.g., `// Calculate compound interest`) prompts Copilot to write the method body. | Useful for implementing standard algorithms or helper functions locally. |
| **`/fix` Chat Command** | Analyzes compilation errors or exceptions in selected code and proposes corrected syntax. | Fixes minor TypeScript type mismatches or missing import paths instantly. |
| **`/explain` Chat Command** | Provides step-by-step plain English explanations of complex or unfamiliar code blocks. | Helps me understand legacy EF Core Fluent API configurations when updating DB models. |
| **`/tests` Chat Command** | Auto-generates unit test setups using frameworks like xUnit or NUnit. | Scaffolds test classes and mocks for service boundary validation. |

---

## Full-Stack Alignment Rule: "Trust but Verify"

When developing full-stack features (ASP.NET Core Web API + Angular), payload mismatches are a huge risk. If the backend changes a property from `InvoiceId` to `Id`, the Angular client will break silently if it is not updated. 

To bridge this gap, I use Copilot's context window.

### Trainee Step-by-Step Flow:
1. Open the backend C# DTO.
2. Open Copilot Chat.
3. Prompt: *"Based on this C# DTO, generate a matching TypeScript interface for my Angular project. Ensure casing matches standard JSON format."*
4. **Verify:** Check that types (e.g., `decimal` to `number`, `DateTime` to `string` or `Date`) match correctly.

### Trainee Alignment Scaffold Example

#### Backend ASP.NET Core DTO:
```csharp
namespace Wipro.Training.Dtos;

// Trainee note: pasting this directly into Copilot generates the Angular model below to prevent payload drift!
public class InvoiceDetailDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsOverdue { get; set; }
}
```

#### Generated frontend TypeScript Interface (`invoice-detail.model.ts`):
```typescript
// Trainee note: verified matching JSON camelCase mappings from C# PascalCase
export interface InvoiceDetail {
  id: number;
  customerName: string;
  totalAmount: number;
  dueDate: string; // ISO string format preferred for json transport
  isOverdue: boolean;
}
```

---

## The 15-Minute Challenge Checklist

This is my checklist as a trainee to rapidly scaffold new features using Copilot:

*   `[ ]` **Step 1: EF Core Fluent Mapping (Minutes 0 - 5)**
    *   Create a clean domain model.
    *   Use Copilot to write the configuration mapping class implements `IEntityTypeConfiguration<T>`.
    *   *Trainee tip:* Explicitly state database column types (e.g., `.HasColumnType("decimal(18,2)")`) to prevent default sql server truncation.
*   `[ ]` **Step 2: Lightweight ASP.NET Core Minimal API (Minutes 5 - 10)**
    *   Scaffold endpoints using `.MapGet`, `.MapPost`, and inject DbContext.
    *   Implement async database queries.
*   `[ ]` **Step 3: Frontend Angular Form Validation (Minutes 10 - 15)**
    *   Build a simple form using Angular `ReactiveFormsModule`.
    *   Define validation rules (e.g., `Validators.required`, `Validators.min(1)`).
    *   Bind properties to match the TypeScript model generated in the Alignment Step.
