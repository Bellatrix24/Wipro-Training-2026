namespace EfCoreLibraryApp.DatabaseFirstModels
{
    // These models represent what you would get from scaffolding an existing database.
    // In a real Database First workflow, you would run:
    // dotnet ef dbcontext scaffold "ConnectionString" Microsoft.EntityFrameworkCore.SqlServer -o DatabaseFirstModels

    public class DbFirstBook
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
    }
}
