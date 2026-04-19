using System;

namespace Day02ControlFlow
{
    class ControlFlow
    {
        static void Main(string[] args)
        {
            // Simple array for testing
            int[] numbers = { 60, 70, 80, 50, 40 };
            int sum = 0;

            // Using a for loop to calculate the sum of numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = sum + numbers[i];
            }

            // Calculating average
            int average = sum / numbers.Length;
            Console.WriteLine("The average score is: " + average);

            // Using if-else statement to check if it's a Pass or Fail
            if (average > 50)
            {
                Console.WriteLine("Status: Pass");
            }
            else
            {
                Console.WriteLine("Status: Fail");
            }

            // Using a switch case to show a message based on rank
            Console.Write("\nEnter your rank (1, 2, or 3): ");
            int rank = int.Parse(Console.ReadLine());

            switch (rank)
            {
                case 1:
                    Console.WriteLine("Excellent! You got the Gold Medal.");
                    break;
                case 2:
                    Console.WriteLine("Great job! You got the Silver Medal.");
                    break;
                case 3:
                    Console.WriteLine("Well done! You got the Bronze Medal.");
                    break;
                default:
                    Console.WriteLine("You did your best! Keep trying.");
                    break;
            }

            // Keep the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
