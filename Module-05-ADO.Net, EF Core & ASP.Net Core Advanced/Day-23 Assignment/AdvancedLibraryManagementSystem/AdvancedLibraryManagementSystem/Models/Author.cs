namespace AdvancedLibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
