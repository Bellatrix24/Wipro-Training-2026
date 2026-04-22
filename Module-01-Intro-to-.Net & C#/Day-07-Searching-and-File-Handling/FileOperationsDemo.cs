using System;
using System.IO; // Required for File Handling

// This script demonstrates basic file operations like Create, Write, Append, and Read.
class FileOperationsDemo
{
    static void Main()
    {
        string filePath = "MyTrainingLog.txt";

        try
        {
            // 1. Create a File
            // Note: File.Create returns a FileStream. We should call .Close() to release the file handle
            // so that other operations can access it immediately.
            File.Create(filePath).Close(); 
            Console.WriteLine("File created successfully.");

            // 2. Write to a File (Overwrites existing content)
            File.WriteAllText(filePath, "Day 7 Training: File Handling in C#.\n");
            Console.WriteLine("Initial text written.");

            // 3. Append to a File (Adds text to the end)
            File.AppendAllText(filePath, "Topic: System.IO Namespace is very powerful!\n");
            File.AppendAllText(filePath, "Status: Lab Exercise Completed.\n");
            Console.WriteLine("Additional text appended.");

            // 4. Read from a File
            Console.WriteLine("\n--- Reading File Content ---");
            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            // Simple catch block to handle any unexpected errors (e.g., path not found)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
