using System;

namespace Day05Practice
{
    // Our custom exception inheriting from Exception class
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

    class CustomExceptionDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Age Verification System ---");
            
            try
            {
                Console.Write("Enter your Age: ");
                int age = int.Parse(Console.ReadLine());

                // Validation Logic
                if (age < 18)
                {
                    // Throwing our specific custom exception
                    throw new InvalidAgeException("Age is below 18. Registration not allowed.");
                }

                Console.WriteLine("Registration successful! Welcome aboard.");
            }
            catch (InvalidAgeException ex)
            {
                // Catching the custom exception first
                Console.WriteLine("VALIDATION FAILED: " + ex.Message);
            }
            catch (FormatException)
            {
                // Catching incorrect input types (like typing 'abc' instead of a number)
                Console.WriteLine("ERROR: That's not a valid number! Please enter digits.");
            }
            catch (Exception ex)
            {
                // General fallback for any other error
                Console.WriteLine("SYSTEM ERROR: " + ex.Message);
            }
            finally
            {
                // The 'finally' block ALWAYS runs, error or no error.
                Console.WriteLine("Note: The try-catch sequence has finished.");
            }
        }
    }
}
