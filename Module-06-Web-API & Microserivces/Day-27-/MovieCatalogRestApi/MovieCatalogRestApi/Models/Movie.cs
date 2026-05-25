using System.ComponentModel.DataAnnotations;

namespace MovieCatalogRestApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie title is required.")]
        [StringLength(150, ErrorMessage = "Movie title cannot exceed 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Release year is required.")]
        [Range(1888, 2100, ErrorMessage = "Release year must be between 1888 and 2100.")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Director association is required.")]
        public int DirectorId { get; set; }

        // Navigation property
        public Director? Director { get; set; }
    }
}
