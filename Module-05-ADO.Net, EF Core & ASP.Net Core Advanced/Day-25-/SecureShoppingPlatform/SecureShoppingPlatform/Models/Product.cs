using System.ComponentModel.DataAnnotations;

namespace SecureShoppingPlatform.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }
    }
}
