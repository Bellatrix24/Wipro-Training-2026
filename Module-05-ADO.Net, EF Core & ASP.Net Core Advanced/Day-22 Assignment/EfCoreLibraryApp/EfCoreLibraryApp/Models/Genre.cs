namespace EfCoreLibraryApp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; } = string.Empty;

        // Many-to-many with Book through BookGenre
        public List<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
