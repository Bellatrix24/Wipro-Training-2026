using System;
using System.Diagnostics; // This contains the 'Stopwatch' class

namespace Day06Practice
{
    class PerformanceTracker
    {
        static void Main(string[] args)
        {
            // Creating a new timer
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Starting a loop of 1,000,000 operations...");

            // Start measuring
            sw.Start();

            // Some work to measure
            long sum = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                sum += i;
            }

            // Stop measuring
            sw.Stop();

            Console.WriteLine("\nWork finished!");
            Console.WriteLine("Time Taken (Milliseconds): " + sw.ElapsedMilliseconds + " ms");
            Console.WriteLine("Time Taken (Ticks): " + sw.ElapsedTicks + " ticks");

            /*
               TRAINEE NOTE:
               Stopwatch provides high-resolution timing. 
               'Ticks' are even smaller than milliseconds, useful for very fast code.
            */
        }
    }
}
