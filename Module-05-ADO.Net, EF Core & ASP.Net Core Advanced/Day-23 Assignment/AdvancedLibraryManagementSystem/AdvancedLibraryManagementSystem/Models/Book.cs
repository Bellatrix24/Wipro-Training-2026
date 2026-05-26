namespace AdvancedLibraryManagementSystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public decimal Price { get; set; }

        public int AuthorID { get; set; }
        public Author? Author { get; set; }

        public List<BookGenre> BookGenres { get; set; } = new();
    }
}
