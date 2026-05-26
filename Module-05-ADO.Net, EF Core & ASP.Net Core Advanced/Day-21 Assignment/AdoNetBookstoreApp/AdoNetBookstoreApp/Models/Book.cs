using System.ComponentModel.DataAnnotations;

namespace AdoNetBookstoreApp.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [StringLength(30, ErrorMessage = "ISBN cannot exceed 30 characters.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(1.00, 1000.00, ErrorMessage = "Price must be between $1.00 and $1000.00.")]
        public decimal Price { get; set; }
    }
}
