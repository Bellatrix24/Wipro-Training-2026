using System.ComponentModel.DataAnnotations;

namespace MovieCatalogRestApi.DTOs
{
    public class DirectorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Director name is required.")]
        [StringLength(100, ErrorMessage = "Director name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio { get; set; } = string.Empty;
    }
}
