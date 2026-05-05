using System;
using System.Reflection;

namespace Day08_Practice
{
    // A simple Student class for Reflection Demo
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

        public void DisplayDetails() { /* Logic here */ }
        public void UpdateMarks(int newMarks) { /* Logic here */ }
    }

    // Generics Demo: A class that can handle any data type <T>
    class GenericsClass<T>
    {
        private T _data;

        public void SetData(T val) => _data = val;
        public T GetData() => _data;

        public void ShowType()
        {
            Console.WriteLine($"Stored Value: {_data} | Data Type: {typeof(T).Name}");
        }
    }

    class AdvancedFeaturesDemo
    {
        static void Main()
        {
            Console.WriteLine("=== Advanced C# Features Demo ===\n");

            // 1. Reflection Demo
            Console.WriteLine("[1] Reflection Demo: Inspecting Student Class");
            Type type = typeof(Student);
            
            Console.WriteLine("Properties found:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
            }

            Console.WriteLine("\nMethods found:");
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"- {method.Name}");
            }

            // 2. Generics Demo
            Console.WriteLine("\n[2] Generics Demo: Handling different types");
            GenericsClass<int> intObj = new GenericsClass<int>();
            intObj.SetData(101);
            intObj.ShowType();

            GenericsClass<string> stringObj = new GenericsClass<string>();
            stringObj.SetData("Wipro Training");
            stringObj.ShowType();

            // 3. Ref & Out Demo (US4 & US5)
            Console.WriteLine("\n[3] Ref & Out Demo:");
            int initialScore = 50;
            Console.WriteLine($"Before Ref: {initialScore}");
            UpdateWithRef(ref initialScore); // Updates the original value
            Console.WriteLine($"After Ref: {initialScore}");

            int total, average;
            GetResults(80, 90, out total, out average); // Returns multiple values
            Console.WriteLine($"Out Results -> Total: {total}, Average: {average}");
        }

        // Ref: Must be initialized before passing. Updates the original memory location.
        static void UpdateWithRef(ref int score)
        {
            score += 10; // Adds 10 to the original variable
        }

        // Out: Doesn't need initialization. Must be assigned inside the method.
        static void GetResults(int m1, int m2, out int sum, out int avg)
        {
            sum = m1 + m2;
            avg = sum / 2;
        }
    }
}
