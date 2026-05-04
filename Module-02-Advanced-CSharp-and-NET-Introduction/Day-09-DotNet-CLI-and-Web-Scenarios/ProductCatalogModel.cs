namespace ProductCatalog.Models
{
    // A simple model class representing a Product in an E-commerce site
    public class Product
    {
        // Unique identifier for the product
        public int Id { get; set; }

        // Name of the product (e.g., Laptop, Mouse)
        public string Name { get; set; }

        // Price of the product
        public decimal Price { get; set; }

        // Number of items available in the warehouse
        public int InStock { get; set; }

        // Simple logic placeholder:
        // Prevent ordering more than stock allows.
        // In a real app, we would check if (orderedQuantity > InStock) then show an error.
    }
}
