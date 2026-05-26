namespace EfCoreLibraryApp.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;

        // Foreign key to Author
        public int AuthorID { get; set; }
        public Author? Author { get; set; }

        // Many-to-many with Genre through BookGenre
        public List<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
