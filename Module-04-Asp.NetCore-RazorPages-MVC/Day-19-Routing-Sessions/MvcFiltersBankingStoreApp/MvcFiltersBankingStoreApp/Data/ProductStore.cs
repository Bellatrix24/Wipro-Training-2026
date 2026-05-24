using System.Collections.Generic;
using MvcFiltersBankingStoreApp.Models;

namespace MvcFiltersBankingStoreApp.Data
{
    public static class ProductStore
    {
        public static List<Product> Products { get; } = new List<Product>
        {
            new Product { Id = 1, Name = "Basic Smartphone", Price = 299.99m, Category = "electronics" },
            new Product { Id = 2, Name = "Standard Laptop", Price = 599.99m, Category = "electronics" },
            new Product { Id = 3, Name = "Introduction to Filters", Price = 19.99m, Category = "books" }
        };
    }
}
