using System;

namespace Day02Loops
{
    class LoopsDemo
    {
        static void Main(string[] args)
        {
            // 1. While Loop - Counting down from 5 to 1
            Console.WriteLine("Countdown starting...");
            int count = 5;
            while (count >= 1)
            {
                Console.WriteLine("Count: " + count);
                count--; // Reducing the count by 1 each time
            }

            // 2. Do-While Loop - Asking for input until user presses 0
            int exitCode;
            do
            {
                Console.WriteLine("\nI am running... Press 0 to exit.");
                exitCode = int.Parse(Console.ReadLine());
            } while (exitCode != 0);

            Console.WriteLine("Loop terminated. Goodbye!");

            // Keep the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
