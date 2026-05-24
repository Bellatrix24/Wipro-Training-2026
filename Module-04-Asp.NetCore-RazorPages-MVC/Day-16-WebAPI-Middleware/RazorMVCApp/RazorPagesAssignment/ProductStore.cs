using System.Collections.Generic;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment
{
    // Natural comment: In-memory store so that the app works dynamically without a database.
    public static class ProductStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product 
            { 
                ProductID = 101, 
                Name = "Laptop Pro", 
                Description = "A powerful laptop suitable for development and heavy coding.", 
                Categories = new List<Category> 
                { 
                    new Category { CategoryID = 1, Name = "Electronics" }, 
                    new Category { CategoryID = 2, Name = "Computers" } 
                } 
            },
            new Product 
            { 
                ProductID = 102, 
                Name = "Ergonomic Office Chair", 
                Description = "High back mesh chair with dynamic lumber support for comfortable work.", 
                Categories = new List<Category> 
                { 
                    new Category { CategoryID = 3, Name = "Furniture" } 
                } 
            }
        };

        public static List<Category> AvailableCategories { get; set; } = new List<Category>
        {
            new Category { CategoryID = 1, Name = "Electronics" },
            new Category { CategoryID = 2, Name = "Computers" },
            new Category { CategoryID = 3, Name = "Furniture" },
            new Category { CategoryID = 4, Name = "Office Supplies" },
            new Category { CategoryID = 5, Name = "Accessories" }
        };
    }
}
