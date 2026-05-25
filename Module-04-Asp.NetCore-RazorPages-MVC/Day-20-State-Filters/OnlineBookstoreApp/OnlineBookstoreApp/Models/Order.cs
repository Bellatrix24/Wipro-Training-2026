using System;
using System.Collections.Generic;

namespace OnlineBookstoreApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
