using System.ComponentModel.DataAnnotations;
using OnlineBookstoreApp.Validation;

namespace OnlineBookstoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(50, ErrorMessage = "Author name cannot exceed 50 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [IsbnValidation]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [PriceRange(1.00, 500.00)]
        public decimal Price { get; set; }
    }
}
