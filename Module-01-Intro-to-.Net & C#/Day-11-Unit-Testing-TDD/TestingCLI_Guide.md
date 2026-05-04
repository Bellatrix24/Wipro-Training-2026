# Testing CLI Cheat Sheet

These are the terminal commands I learned for setting up and running tests in .NET:

### 1. Create a Test Project
This creates a new project using the MSTest framework.
```bash
dotnet new mstest -n DemoApp.Tests
```

### 2. Link Test Project to App Code
The test project needs to "know" about the code it is testing.
```bash
dotnet add reference ../DemoApp/DemoApp.csproj
```

### 3. Run All Test Cases
This command scans the project for `[TestMethod]` attributes and runs them.
```bash
dotnet test
```
