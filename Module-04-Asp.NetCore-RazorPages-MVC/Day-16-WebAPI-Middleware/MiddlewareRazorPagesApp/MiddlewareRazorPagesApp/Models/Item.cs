using System.ComponentModel.DataAnnotations;

namespace MiddlewareRazorPagesApp.Models
{
    // Natural comment: Simple item model with data validation annotations
    public class Item
    {
        [Required(ErrorMessage = "Item Name is required.")]
        [Display(Name = "Item Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Item Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Item Description is required.")]
        [Display(Name = "Item Description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}
