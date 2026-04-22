using System;

// This script shows how to use standard library functions and NuGet concepts
namespace Day03Practice
{
    class PackageDemo
    {
        static void Main(string[] args)
        {
            // 1. Using System.Math for a basic calculation
            double number = 625;
            double root = Math.Sqrt(number); 
            Console.WriteLine("Square root of " + number + " is: " + root);

            // 2. Placeholder for QR Code generation (External Library Concept)
            // To use this, we would usually run: dotnet add package QRCoder
            
            /*
            // Initializing QRCoder logic:
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Hello Wipro!", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            
            Console.WriteLine("QR Code created successfully!");
            */

             Console.WriteLine("\nMath demo worked! QR logic is ready in comments.");
        }
    }
}
