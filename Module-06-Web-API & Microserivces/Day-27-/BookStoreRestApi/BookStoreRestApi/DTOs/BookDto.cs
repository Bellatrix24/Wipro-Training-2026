using System.ComponentModel.DataAnnotations;

namespace BookStoreRestApi.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        [StringLength(150, ErrorMessage = "Book title cannot exceed 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publication year is required.")]
        [Range(1000, 2100, ErrorMessage = "Publication year must be between 1000 and 2100.")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Author association is required.")]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; } = string.Empty;
    }
}
