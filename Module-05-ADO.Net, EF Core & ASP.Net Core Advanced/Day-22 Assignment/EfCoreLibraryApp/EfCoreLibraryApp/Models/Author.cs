namespace EfCoreLibraryApp.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Bio { get; set; }

        // Navigation: one author has many books
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
