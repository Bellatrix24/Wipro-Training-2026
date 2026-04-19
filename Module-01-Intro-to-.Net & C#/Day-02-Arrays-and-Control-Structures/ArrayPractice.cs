using System;

namespace Day02Arrays
{
    class ArrayPractice
    {
        static void Main(string[] args)
        {
            // Declaring an array of 5 integers (using student marks as an example)
            int[] marks = { 85, 90, 78, 92, 88 };

            Console.WriteLine("Printing student marks from the array:");

            // Using a foreach loop to print each item in the array
            foreach (int m in marks)
            {
                Console.WriteLine("Mark: " + m);
            }

            // Keep the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
