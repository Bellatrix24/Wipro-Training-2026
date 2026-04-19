using System;

namespace Day01Fundamentals
{
    // Simple class for practice
    class Student
    {
        public string Name;
        public int Num1;
        public int Num2;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Hello World
            Console.WriteLine("Hello World! Welcome to my Day 1 Training.");
            Console.WriteLine("------------------------------------------");

            Student s = new Student();

            // 2. User Input
            Console.Write("Enter your name: ");
            s.Name = Console.ReadLine();

            Console.WriteLine("Nice to meet you, " + s.Name + "!");

            // 3. Simple Addition
            Console.Write("Enter first number to add: ");
            s.Num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number to add: ");
            s.Num2 = int.Parse(Console.ReadLine());

            int sum = s.Num1 + s.Num2;

            Console.WriteLine("The sum of your numbers is: " + sum);

            // Keeping the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
