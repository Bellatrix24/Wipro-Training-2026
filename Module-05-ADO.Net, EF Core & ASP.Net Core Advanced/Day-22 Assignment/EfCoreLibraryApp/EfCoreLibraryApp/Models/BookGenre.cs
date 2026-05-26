namespace EfCoreLibraryApp.Models
{
    // Join entity for many-to-many between Book and Genre
    public class BookGenre
    {
        public int BookID { get; set; }
        public Book? Book { get; set; }

        public int GenreID { get; set; }
        public Genre? Genre { get; set; }
    }
}
