using System;
using System.Collections.Generic;

namespace Day04Practice
{
    // Simple Order model
    class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
    }

    class EcommerceScenario
    {
        static void Main(string[] args)
        {
            // 1. List: Stores all our orders
            List<Order> orders = new List<Order>();
            orders.Add(new Order { OrderId = 1, ProductName = "Keyboard" });
            orders.Add(new Order { OrderId = 2, ProductName = "Mouse" });

            // 2. Dictionary: Maps Customer ID to their Name (Quick lookup)
            Dictionary<int, string> customers = new Dictionary<int, string>();
            customers.Add(1001, "Amit");
            customers.Add(1002, "Sita");

            // 3. Queue (FIFO - First In First Out)
            // Just like a billing line: the first one in is the first one out!
            Queue<string> orderProcessing = new Queue<string>();
            orderProcessing.Enqueue("Order_001");
            orderProcessing.Enqueue("Order_002");
            Console.WriteLine("Processing " + orderProcessing.Dequeue()); // Dispatches Order_001

            // 4. Stack (LIFO - Last In First Out)
            // Like a pile of plates: the last status added is the first one we see.
            Stack<string> orderUpdates = new Stack<string>();
            orderUpdates.Push("Order Received");
            orderUpdates.Push("Packaging Done");
            orderUpdates.Push("Out for Delivery");

            Console.WriteLine("\nLatest Status: " + orderUpdates.Peek()); // Most recent update
            
            Console.WriteLine("\n--- E-Commerce Logic Complete ---");
        }
    }
}
