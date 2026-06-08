# Day 43: AI Foundations

## Technical Environment Setup

This log outlines the steps I took to install the Microsoft toolchain ecosystem for ML.NET and Semantic Kernel integration.

### Installation Steps

1.  **Add ML.NET CLI Tooling:**
    ```bash
    dotnet tool install -g Microsoft.ML.ModelBuilder.CLI
    ```
2.  **Add ML.NET NuGet Packages to Web API Project:**
    ```bash
    dotnet add package Microsoft.ML
    dotnet add package Microsoft.ML.FastTree
    ```
3.  **Add Semantic Kernel for Azure OpenAI Orchestration:**
    ```bash
    dotnet add package Microsoft.SemanticKernel
    ```

### Local Verification Parameters

To ensure our local environment is configured correctly, we verify using the following checks:
*   Run `dotnet tool list -g` to check if `Microsoft.ML.ModelBuilder.CLI` is present.
*   Verify that `appsettings.Development.json` has the environment variable for Azure OpenAI endpoints defined.
*   Run the background worker and inspect console output for: `"Predictive Validation Background Service started."`

### Source Code Repository

All portfolio checkpoints, code configurations, and trainee study notes are tracked in our official repository:
[https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
