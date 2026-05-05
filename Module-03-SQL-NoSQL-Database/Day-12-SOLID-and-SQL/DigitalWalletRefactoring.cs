using System;
using System.Collections.Generic;

namespace DigitalWalletSystem
{
    /// <summary>
    /// IPayment interface defines the contract for various payment methods.
    /// This adheres to the Dependency Inversion Principle (DIP) and Open/Closed Principle (OCP).
    /// </summary>
    public interface IPayment
    {
        void ProcessPayment(double amount);
    }

    /// <summary>
    /// INotificationService defines the contract for sending notifications.
    /// Adheres to the Interface Segregation Principle (ISP).
    /// </summary>
    public interface INotificationService
    {
        void SendNotification(string message);
    }

    /// <summary>
    /// UPI Payment implementation.
    /// </summary>
    public class UpiPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing UPI payment of ${amount}...");
        }
    }

    /// <summary>
    /// Card Payment implementation.
    /// </summary>
    public class CardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing Card payment of ${amount}...");
        }
    }

    /// <summary>
    /// Net Banking Payment implementation.
    /// </summary>
    public class NetBankingPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing Net Banking payment of ${amount}...");
        }
    }

    /// <summary>
    /// Email Notification implementation.
    /// </summary>
    public class EmailNotification : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    /// <summary>
    /// TransactionLogger handles logging transaction details.
    /// Adheres to Single Responsibility Principle (SRP).
    /// </summary>
    public class TransactionLogger
    {
        public void LogTransaction(string details)
        {
            Console.WriteLine($"Logging Transaction: {details}");
        }
    }

    /// <summary>
    /// OrderService orchestrates the payment process.
    /// Adheres to DIP by depending on IPayment and INotificationService abstractions.
    /// </summary>
    public class OrderService
    {
        private readonly IPayment _paymentMethod;
        private readonly INotificationService _notificationService;
        private readonly TransactionLogger _logger;

        public OrderService(IPayment paymentMethod, INotificationService notificationService, TransactionLogger logger)
        {
            _paymentMethod = paymentMethod;
            _notificationService = notificationService;
            _logger = logger;
        }

        public void CompleteOrder(double amount)
        {
            _paymentMethod.ProcessPayment(amount);
            _logger.LogTransaction($"Order completed for amount ${amount}");
            _notificationService.SendNotification($"Payment of ${amount} was successful.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection (Manual)
            var upi = new UpiPayment();
            var emailService = new EmailNotification();
            var logger = new TransactionLogger();

            var orderService = new OrderService(upi, emailService, logger);
            orderService.CompleteOrder(150.75);

            Console.WriteLine("\n--- Switching Payment Method ---");

            var card = new CardPayment();
            var cardOrderService = new OrderService(card, emailService, logger);
            cardOrderService.CompleteOrder(299.99);
        }
    }
}
