using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesAssignment.Models
{
    // Natural comment: Product model with simple validation and category lists
    public class Product
    {
        [Required(ErrorMessage = "Product ID is required.")]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Product Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        // Complex property representing a list of categories
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
