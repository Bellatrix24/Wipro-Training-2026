using System;
using System.Collections; // Required for older Non-Generic collections

namespace Day04Practice
{
    class NonGenericDemo
    {
        static void Main(string[] args)
        {
            // 1. Hashtable with mixed data types
            // Everything is stored as Type 'Object' internally
            Hashtable employee = new Hashtable();
            employee.Add("Name", "Rahul"); // String
            employee.Add("Age", 24);       // Int
            employee.Add("Salary", 45000.00); // Double

            Console.WriteLine("--- Hashtable (Non-Generic) ---");
            Console.WriteLine("Name is: " + employee["Name"]);

            // 2. Stack with mixed types
            Stack stack = new Stack();
            stack.Push(101);      // Int
            stack.Push("Admin");  // String
            stack.Push(true);     // Bool

            Console.WriteLine("\n--- Popping from Non-Generic Stack ---");
            // Risk: We don't know the type of data we are popping without checking
            while (stack.Count > 0)
            {
                object item = stack.Pop();
                Console.WriteLine("Item: " + item + " | Type: " + item.GetType());
            }

            /* 
               STUDENT NOTE: 
               These are old classes. They store everything as 'Object' 
               (which means boxing happens for integers). 
               They are NOT type-safe compared to List<T>.
            */
        }
    }
}
