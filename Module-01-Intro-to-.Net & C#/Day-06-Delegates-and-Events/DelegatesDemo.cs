using System;

namespace Day06Practice
{
    // 1. Defining the Delegate (blueprint for a function)
    // This can point to any method that takes two integers
    public delegate void MathOperation(int a, int b);

    class DelegatesDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Simple Delegate Practice ---");

            // 2. Pointing the delegate to the Add method
            // The delegate variable 'op' now 'holds' the logic for addition
            MathOperation op = Add; 
            op(20, 10); // Calling the method through its 'pointer'

            // 3. Re-pointing 'op' to the Subtract method
            op = Subtract;
            op(20, 10);

            // 4. Re-pointing to Multiply
            op = Multiply;
            op(20, 10);

            Console.WriteLine("\nNote: One delegate variable can point to different methods!");
        }

        // Methods that match the delegate's signature (two ints)
        static void Add(int x, int y)
        {
            Console.WriteLine("Addition Result: " + (x + y));
        }

        static void Subtract(int x, int y)
        {
            Console.WriteLine("Subtraction Result: " + (x - y));
        }

        static void Multiply(int x, int y)
        {
            Console.WriteLine("Multiplication Result: " + (x * y));
        }
    }
}
