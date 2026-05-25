using System.ComponentModel.DataAnnotations;

namespace BookStoreRestApi.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Biography cannot exceed 500 characters.")]
        public string Biography { get; set; } = string.Empty;
    }
}
