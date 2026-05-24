using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    // Natural comment: User model with simple properties and a nested Address property.
    public class User
    {
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must be a valid number between 1 and 120.")]
        public int? Age { get; set; }

        // Complex model binding: Nested model property
        [Required(ErrorMessage = "Address details are required.")]
        public Address Address { get; set; } = new Address();
    }
}
