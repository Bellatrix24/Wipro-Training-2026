using System;

namespace Day04Practice
{
    // 1. Base Class: Parent
    class Order
    {
        // 'virtual' means child classes ARE ALLOWED to change this method
        public virtual void ProcessOrder()
        {
            Console.WriteLine("Base: Processing general order details...");
        }
    }

    // 2. Derived Class: Child
    class DigitalOrder : Order
    {
        // 'override' means we are CHOOSING to change the behavior for this specific child
        public override void ProcessOrder()
        {
            Console.WriteLine("Digital: Order confirmed! Sending download link to user's email.");
        }
    }

    class PolymorphismDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Polymorphism (Method Overriding) ---");

            // Example 1: Standard Order
            Order normalOrder = new Order();
            normalOrder.ProcessOrder();

            // Example 2: Digital Order behavior using a Parent reference
            // This is the heart of polymorphism!
            Order myDigitalOrder = new DigitalOrder();
            myDigitalOrder.ProcessOrder(); 

            Console.WriteLine("\nSTUDENT NOTE: We use 'virtual' in the parent and 'override' in the child.");
        }
    }
}
