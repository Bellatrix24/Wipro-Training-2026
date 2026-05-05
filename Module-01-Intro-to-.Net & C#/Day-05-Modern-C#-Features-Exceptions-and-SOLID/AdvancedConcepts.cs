using System;
using System.Reflection; // Needed for the Reflection demo

namespace Day05Practice
{
    // 1. Delegate Definition
    // A delegate is like a 'contract' or 'pointer' for a method.
    public delegate void MyTask(string msg);

    class AdvancedConcepts
    {
        public void SampleMethod() { }

        static void Main(string[] args)
        {
            // --- DELEGATES ---
            // Pointing the delegate to our actual method
            MyTask task = ShowMessage;
            Console.WriteLine("--- Delegate Demo ---");
            task("Function pointer is working!");

            // --- REFLECTION ---
            // Reflection allows us to look inside our code while it's running
            Console.WriteLine("\n--- Reflection Demo ---");
            Type typeInfo = typeof(AdvancedConcepts);
            Console.WriteLine("Analyzing Class: " + typeInfo.Name);

            MethodInfo[] methods = typeInfo.GetMethods();
            Console.WriteLine("Found some methods:");
            foreach (var m in methods)
            {
                // We'll see built-in methods too, like ToString()
                Console.WriteLine("-> Method Name: " + m.Name);
            }

            /*
               --- UNIT TESTING / TDD NOTES ---
               TDD (Test-Driven Development) follows the 'Red-Green-Refactor' cycle:
               
               1. RED: Write a test for a feature that doesn't exist yet (it fails).
               2. GREEN: Write the simplest code to make that test pass.
               3. REFACTOR: Improve the code quality while ensuring the test still passes.
               
               This ensures our code is always tested and works as expected!
            */
        }

        static void ShowMessage(string s)
        {
            Console.WriteLine("Trainee Log: " + s);
        }
    }
}
