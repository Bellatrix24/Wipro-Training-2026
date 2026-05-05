using System;
using System.Collections.Generic;

/* 
 * TRAINEE NOTE: 
 * Today I explored how Design Patterns help us write code that is easy to scale and maintain.
 * Instead of writing one giant "Main" method, I used patterns to separate different responsibilities.
 * This makes the code much cleaner and less "fragile" when we want to add new features!
 */

namespace Day13DesignPatterns
{
    // --- 1. THE PRODUCT (The thing we are building) ---
    public abstract class Product
    {
        public string Name { get; set; }
        public abstract double GetPrice();
    }

    public class Electronics : Product
    {
        public Electronics() { Name = "High-End Laptop"; }
        public override double GetPrice() => 1200.00;
    }

    public class Clothing : Product
    {
        public Clothing() { Name = "Cotton T-Shirt"; }
        public override double GetPrice() => 40.00;
    }

    // --- 2. FACTORY PATTERN (Creational) ---
    // Why: To hide the complex object creation logic from the user. 
    // If I want to add "Groceries" later, I only change the Factory, not the whole system!
    public class ProductFactory
    {
        public static Product CreateProduct(string type)
        {
            return type.ToLower() switch
            {
                "electronics" => new Electronics(),
                "clothing" => new Clothing(),
                _ => throw new ArgumentException("Unknown product type")
            };
        }
    }

    // --- 3. DECORATOR PATTERN (Structural) ---
    // Why: To add new behavior (like a discount) to an object without changing the original class.
    // It "wraps" the product and modifies the price dynamically.
    public abstract class ProductDecorator : Product
    {
        protected Product _product;
        public ProductDecorator(Product product) { _product = product; }
    }

    public class DiscountDecorator : ProductDecorator
    {
        public DiscountDecorator(Product product) : base(product) { Name = _product.Name + " (With 10% Trainee Discount)"; }
        public override double GetPrice() => _product.GetPrice() * 0.9; // Apply 10% discount
    }

    // --- 4. STRATEGY PATTERN (Behavioral) ---
    // Why: To allow the user to choose different algorithms (payment methods) at runtime.
    // It follows the Open-Closed Principle because we can add new methods without changing OrderManagement.
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    public class UPILogic : IPaymentStrategy
    {
        public void Pay(double amount) => Console.WriteLine($"Processing {amount:C} via UPI. (Fast & Secure!)");
    }

    public class CreditCardLogic : IPaymentStrategy
    {
        public void Pay(double amount) => Console.WriteLine($"Processing {amount:C} via Credit Card. (Points earned!)");
    }

    // --- 5. OBSERVER PATTERN (Behavioral) ---
    // Why: To notify other parts of the system when something important happens (like an order update).
    public class NotificationService
    {
        public void Update(string status)
        {
            Console.WriteLine($"[NOTIFICATION SERVICE]: Order status changed to: {status}");
        }
    }

    // --- MAIN SYSTEM ---
    class OrderManagementSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Wipro E-Commerce Order System (Day 13) ---\n");

            // 1. Factory: Creating a product
            Product myOrder = ProductFactory.CreateProduct("electronics");
            Console.WriteLine($"Step 1: Created {myOrder.Name} using Factory Pattern.");

            // 2. Decorator: Applying a discount
            myOrder = new DiscountDecorator(myOrder);
            Console.WriteLine($"Step 2: Applied {myOrder.Name}. New Price: {myOrder.GetPrice():C}");

            // 3. Strategy: Choosing payment
            IPaymentStrategy paymentMethod = new UPILogic(); // Student choice: UPI is trending!
            Console.WriteLine("Step 3: User selected UPI Payment Strategy.");
            paymentMethod.Pay(myOrder.GetPrice());

            // 4. Observer: Notifying the user
            NotificationService notifier = new NotificationService();
            notifier.Update("Payment Received / Order Shipped");

            Console.WriteLine("\n--- Order Completed Successfully! ---");
        }
    }
}
