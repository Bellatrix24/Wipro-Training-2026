using System.ComponentModel.DataAnnotations;

namespace OnlineBookstoreApp.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30, ErrorMessage = "Username cannot exceed 30 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "Customer"; // Defaults to Customer, but can be Admin
    }
}
