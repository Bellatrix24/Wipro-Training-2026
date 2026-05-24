using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    // Natural comment: Nested model representing address details for complex model binding demo.
    public class Address
    {
        [Required(ErrorMessage = "Street address is required.")]
        [Display(Name = "Street Address")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code must be exactly 5 digits.")]
        public string ZipCode { get; set; } = string.Empty;
    }
}
