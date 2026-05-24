using System;
using System.Collections.Generic;

namespace AdvancedRoutingEcommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
