using System;
using System.Collections.Generic;
using System.Linq; // Needed for the .Where() filtering

namespace Day04Practice
{
    class GenericCollections
    {
        static void Main(string[] args)
        {
            // 1. Creating a List of strings for phone models
            // List<T> is dynamic - the CLR increases its size automatically as we add items!
            List<string> phones = new List<string>();

            // Adding items
            phones.Add("iPhone 15");
            phones.Add("iPhone 15 Pro");
            phones.Add("Samsung S24");
            phones.Add("Google Pixel 8 Pro");

            Console.WriteLine("Initial Phone List Count: " + phones.Count);

            // Removing an item
            phones.Remove("Samsung S24");

            // 2. Using LINQ to find phones that have the word 'Pro'
            // .Where() checks each item based on our condition
            var proModels = phones.Where(p => p.Contains("Pro"));

            Console.WriteLine("\n--- Latest 'Pro' Mobile Phones ---");
            foreach (var phone in proModels)
            {
                Console.WriteLine("Found: " + phone);
            }

            Console.WriteLine("\nNote: The CLR handles dynamic resizing in the background for List<T>.");
        }
    }
}
