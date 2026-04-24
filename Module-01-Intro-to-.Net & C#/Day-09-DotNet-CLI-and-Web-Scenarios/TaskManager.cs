using System;
using System.Collections.Generic;

namespace TaskManagerApp
{
    class Program
    {
        // Simple list to store our tasks as strings
        static List<string> taskList = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("--- My Task List Manager ---");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // Method to add a task to the list
        static void AddTask()
        {
            Console.Write("Enter the task description: ");
            string task = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(task))
            {
                taskList.Add(task);
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty!");
            }
        }

        // Method to display all tasks in the list
        static void ViewTasks()
        {
            Console.WriteLine("\nYour Current Tasks:");
            if (taskList.Count == 0)
            {
                Console.WriteLine("(No tasks yet!)");
            }
            else
            {
                for (int i = 0; i < taskList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {taskList[i]}");
                }
            }
        }
    }
}
