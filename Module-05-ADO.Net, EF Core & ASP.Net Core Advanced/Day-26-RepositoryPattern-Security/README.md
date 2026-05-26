# Day 26: Repository Pattern & SDLC Security Overview

This folder contains my training notes and practicing code files for Day 26. Today's lab focus was on implementing the Repository Design Pattern to fully decouple our data access pathways and analyzing the SDLC security lifecycle routines required to protect relational databases from cyber attacks.

---

## Folder Structure of Decoupled StudentRepositoryDemo Project

In our lab walkthrough, we set up a clean Model-View-Controller project layout to separate our data components from visual views. Here is the structure map of our decoupled project layout:

```text
StudentRepositoryDemo/
│
├── Data/
│   └── ApplicationDbContext.cs         # EF Core bridge context
│
├── Models/
│   └── Student.cs                      # Student structural database schema entity
│
├── Repositories/
│   ├── IStudentRepository.cs           # Scoped CRUD operations contract interface
│   └── StudentRepository.cs            # Concrete EF Core repository database mapping
│
├── Controllers/
│   └── StudentController.cs            # Scoped context controller injecting IStudentRepository
│
└── Views/
    └── Student/
        └── Index.cshtml                # Razor View template displaying data collection tables
```

---

## Database Connection Configuration Block

To connect securely to our local SQL Server development instance, we define local connection strings with parameters that enforce encryption. Here is our standard secure lab configuration template:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=WiproStudentDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

* **Server=(localdb)\\MSSQLLocalDB**: Focuses connection targeting to local Express database engines.
* **Database=WiproStudentDB**: Designates the Wipro database catalog.
* **Trusted_Connection=True**: Authenticates the process securely using Windows credentials.
* **Encrypt=True**: Enforces Transport Layer Security (TLS) encryption to safeguard our SQL pipeline.
* **TrustServerCertificate=True**: Bypasses local SSL certificate handshake trust issues during local lab operations.

---

## Practice Assets

Our practicing directory contains the following training assets:
* **[Repository_And_SdlcSecurity_Notes.md](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-26-RepositoryPattern-Security/Repository_And_SdlcSecurity_Notes.md)**: Daily learning notes covering repository layer decoupling, security strategies during the SDLC, and foreign key referential integrity parameters.
* **[StudentSystem_DataLayers.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-26-RepositoryPattern-Security/StudentSystem_DataLayers.cs)**: Unified C# file defining the `Student` entity schema, context container, `IStudentRepository` interface contract, and concrete `StudentRepository` operations.
* **[StudentSystem_ControllerAndViews.cs](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-05-ADO.Net,%20EF%20Core%20&%20ASP.Net%20Core%20Advanced/Day-26-RepositoryPattern-Security/StudentSystem_ControllerAndViews.cs)**: Unified script demonstrating standard constructor injection inside the `StudentController` action handlers alongside the `@foreach` iteration Razor View snippet.

---

## Repository Tracking

Our daily work maps out to our training repository:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
