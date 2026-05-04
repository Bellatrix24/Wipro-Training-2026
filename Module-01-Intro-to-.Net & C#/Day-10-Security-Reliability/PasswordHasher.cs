using System;
using System.Security.Cryptography;
using System.Text;

// This script demonstrates User Story 1 & 2: Hashing passwords for security.
// We use SHA256 to ensure passwords are never stored as plain text.
class PasswordHasher
{
    static void Main()
    {
        Console.WriteLine("--- Security Lab: Password Hashing ---");
        
        Console.Write("Enter a new password to hash: ");
        string plainTextPassword = Console.ReadLine();

        if (string.IsNullOrEmpty(plainTextPassword))
        {
            Console.WriteLine("Password cannot be empty.");
            return;
        }

        using (SHA256 sha256 = SHA256.Create())
        {
            // Step 1: Convert the string password into a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainTextPassword);
            
            // Step 2: Compute the hash bytes
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Step 3: Convert the bytes into a readable Hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            string hashedPassword = sb.ToString();

            // Storing hashes instead of plain text protects user data
            Console.WriteLine("\n[Lab Results]");
            Console.WriteLine($"Original: {plainTextPassword}");
            Console.WriteLine($"SHA256 Hash: {hashedPassword}");
        }

        Console.WriteLine("\nNote: In a real app, we would also use a 'salt' for extra security.");
    }
}
