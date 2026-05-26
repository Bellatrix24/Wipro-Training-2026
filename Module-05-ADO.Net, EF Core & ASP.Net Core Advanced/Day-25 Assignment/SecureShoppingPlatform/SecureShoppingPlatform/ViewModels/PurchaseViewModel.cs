using System.ComponentModel.DataAnnotations;
using SecureShoppingPlatform.Models;

namespace SecureShoppingPlatform.ViewModels
{
    public class PurchaseViewModel
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; } = 1;

        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; } = string.Empty;
    }
}
