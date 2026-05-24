using System;
using System.Collections.Generic;
using AdvancedRoutingEcommerceApp.Models;

namespace AdvancedRoutingEcommerceApp.Data
{
    public static class OrderStore
    {
        public static List<Order> Orders { get; } = new List<Order>
        {
            new Order
            {
                Id = 101,
                Username = "john",
                Items = new List<string> { "Developer Laptop", "Clean Coding Patterns" },
                OrderDate = DateTime.Now.AddDays(-5),
                TotalAmount = 1235.00m
            },
            new Order
            {
                Id = 102,
                Username = "john",
                Items = new List<string> { "Wireless Headphones" },
                OrderDate = DateTime.Now.AddDays(-1),
                TotalAmount = 150.00m
            },
            new Order
            {
                Id = 103,
                Username = "jane",
                Items = new List<string> { "Mastering ASP.NET Core", "Smart Watch" },
                OrderDate = DateTime.Now.AddDays(-3),
                TotalAmount = 295.00m
            }
        };
    }
}
