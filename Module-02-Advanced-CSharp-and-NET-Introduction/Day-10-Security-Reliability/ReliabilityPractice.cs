using System;
using System.Diagnostics;
using System.IO;

// This script practices Error Handling and Performance Monitoring.
class ReliabilityPractice
{
    static void Main()
    {
        // Using a Stopwatch to measure task performance (learned in Day 6/7)
        Stopwatch timer = new Stopwatch();
        timer.Start();

        Console.WriteLine("--- Reliability Lab: Error Handling & Performance ---");

        try
        {
            // Simulating a calculation that might fail
            Console.Write("Enter a number to divide 500 by: ");
            string input = Console.ReadLine();
            int divisor = int.Parse(input);
            
            int result = 500 / divisor;
            Console.WriteLine($"Success! Result is: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Reliability Error: You cannot divide by zero.");
            LogError("Attempted division by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Reliability Error: Please enter a valid whole number.");
            LogError("Invalid input format entered.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            LogError($"Unexpected Error: {ex.Message}");
        }
        finally
        {
            // Finally blocks are great for cleanup or final status updates
            timer.Stop();
            Console.WriteLine($"\nProcess completed in {timer.ElapsedMilliseconds}ms.");
            Console.WriteLine("The 'finally' block ensures this message always appears.");
        }
    }

    static void LogError(string message)
    {
        // Simulate a simple log by appending an error message to a file called applog.txt
        string logFile = "applog.txt";
        string logEntry = $"[{DateTime.Now}] ERROR: {message}" + Environment.NewLine;
        
        try
        {
            File.AppendAllText(logFile, logEntry);
            Console.WriteLine("-> Error has been recorded in applog.txt");
        }
        catch (Exception)
        {
            Console.WriteLine("-> Failed to write to log file.");
        }
    }
}
