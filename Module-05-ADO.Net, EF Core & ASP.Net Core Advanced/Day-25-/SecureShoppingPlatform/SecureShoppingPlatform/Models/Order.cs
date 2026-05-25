using System.ComponentModel.DataAnnotations;

namespace SecureShoppingPlatform.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; } = string.Empty;

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
