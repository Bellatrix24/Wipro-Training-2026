using System;

namespace Day05Practice
{
    class ModernFeatures
    {
        static void Main(string[] args)
        {
            // 1. Inline Out Variables (C# 7.0)
            // We declare 'outputValue' directly inside the TryParse call!
            Console.WriteLine("Testing Inline Out Variables:");
            if (int.TryParse("500", out int outputValue))
            {
                Console.WriteLine("Parsed Value: " + outputValue);
            }

            // 2. Tuples (C# 7.0)
            // Returning multiple values without using a class or struct
            var circle = CalculateCircle(7);
            Console.WriteLine($"\nCircle - Area: {circle.Area:F2}, Perimeter: {circle.Perimeter:F2}");

            // 3. Pattern Matching (Switch Statement)
            Console.WriteLine("\nTesting Pattern Matching:");
            object[] myStuff = { 42, 12.5, "Hello Wipro" };

            foreach (var item in myStuff)
            {
                switch (item)
                {
                    case int i:
                        Console.WriteLine($"{i} is an Integer.");
                        break;
                    case double d:
                        Console.WriteLine($"{d} is a Double.");
                        break;
                    case string s:
                        Console.WriteLine($"'{s}' is a String.");
                        break;
                }
            }
        }

        // Method that returns a Tuple
        static (double Area, double Perimeter) CalculateCircle(double radius)
        {
            double a = Math.PI * radius * radius;
            double p = 2 * Math.PI * radius;
            return (a, p); // Returning named tuple values
        }
    }
}
