using System;

// This is a simple demonstration of the Request-Response Pipeline.
// In a real ASP.NET Core application, this logic lives in Program.cs.

class MiddlewareDemo
{
    static void Main()
    {
        Console.WriteLine("--- Web Pipeline: Middleware Demo ---");

        // Middleware sits between the request and the final response.
        // It can inspect, modify, or even stop the request from moving forward.

        /* 
        Simplified Visual of app.Use:
        
        app.Use(async (context, next) => 
        {
            // 1. Logic before the next component
            Console.WriteLine("Request received"); 
            
            // 2. Call the next middleware in the pipeline
            await next(); 
            
            // 3. Logic after the next component returns
            Console.WriteLine("Response sent"); 
        });
        */

        // Simulating the flow:
        Console.WriteLine("[Middleware 1] Request received. Logging start time...");
        
        Console.WriteLine("   [Page Logic] Generating content for the user...");
        
        Console.WriteLine("[Middleware 1] Response sent. Logging end time...");
        
        Console.WriteLine("\nMiddleware is like a gatekeeper for every web request!");
    }
}
