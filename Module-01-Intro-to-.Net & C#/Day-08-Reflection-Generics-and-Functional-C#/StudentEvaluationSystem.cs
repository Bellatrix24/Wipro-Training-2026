using System;
using System.Collections.Generic;

namespace Day08_Practice
{
    // US1: Define a delegate for evaluation logic
    public delegate void EvaluatePerformance(int totalMarks);

    class StudentEvaluationSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- College Activity Evaluation System ---");

            // List of student marks for testing
            List<int> studentMarks = new List<int> { 45, 60, 85, 30, 92, 55 };

            // 1. Anonymous Method (US1 & US5)
            // Used to calculate and display performance based on marks
            EvaluatePerformance performanceReview = delegate (int marks)
            {
                string status = marks >= 50 ? "Pass" : "Fail";
                Console.WriteLine($"Total Marks: {marks} | Result: {status}");
            };

            Console.WriteLine("\n[1] Performance Evaluation using Anonymous Methods:");
            foreach (var marks in studentMarks)
            {
                performanceReview(marks);
            }

            // 2. Lambda Expressions with Built-in Delegates (Func, Action, Predicate)
            
            // Predicate<T>: Check if student is eligible (marks > 50)
            Predicate<int> isEligible = marks => marks > 50;

            // Func<int, string>: Get a descriptive grade based on marks
            Func<int, string> getGrade = marks =>
            {
                if (marks > 75) return "Top Performer (A+)";
                if (marks >= 50) return "Average (B)";
                return "Needs Improvement (C)";
            };

            // Action<int>: Print the final summary
            Action<int> printSummary = marks =>
            {
                if (isEligible(marks))
                {
                    Console.WriteLine($"Student with {marks} marks is {getGrade(marks)}");
                }
            };

            Console.WriteLine("\n[2] Filtering Top Performers (> 75) using Lambdas:");
            // Using a lambda to filter a list
            List<int> topPerformers = studentMarks.FindAll(m => m > 75);
            topPerformers.ForEach(m => Console.WriteLine($"Found Top Scorer: {m}"));

            Console.WriteLine("\n[3] Eligibility & Grade Summary:");
            foreach (var marks in studentMarks)
            {
                printSummary(marks);
            }

            Console.WriteLine("\nEvaluation Complete.");
        }
    }
}
