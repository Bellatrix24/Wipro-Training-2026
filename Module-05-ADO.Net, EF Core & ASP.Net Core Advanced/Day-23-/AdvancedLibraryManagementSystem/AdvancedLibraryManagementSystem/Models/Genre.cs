namespace AdvancedLibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookGenre> BookGenres { get; set; } = new();
    }
}
