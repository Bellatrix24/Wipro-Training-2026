using System.Collections.Generic;
using AdvancedRoutingEcommerceApp.Models;

namespace AdvancedRoutingEcommerceApp.Data
{
    public static class ProductStore
    {
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Developer Laptop",
                Category = "electronics",
                Price = 1200.00m,
                Description = "A high-end developer laptop with 32GB RAM and 1TB SSD."
            },
            new Product
            {
                Id = 2,
                Name = "Wireless Headphones",
                Category = "electronics",
                Price = 150.00m,
                Description = "Noise-cancelling wireless over-ear headphones."
            },
            new Product
            {
                Id = 3,
                Name = "Smart Watch",
                Category = "electronics",
                Price = 250.00m,
                Description = "Fitness tracker and smart watch with heart rate monitor."
            },
            new Product
            {
                Id = 4,
                Name = "Mastering ASP.NET Core",
                Category = "books",
                Price = 45.00m,
                Description = "A complete guide to building web apps and APIs with .NET Core."
            },
            new Product
            {
                Id = 5,
                Name = "Clean Coding Patterns",
                Category = "books",
                Price = 35.00m,
                Description = "Learn how to write readable, maintainable, and clean code."
            },
            new Product
            {
                Id = 6,
                Name = "Mystery at the Lighthouse",
                Category = "books",
                Price = 15.00m,
                Description = "A thrilling mystery novel set on a remote island."
            }
        };
    }
}
