using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WiproTraining.Day16.Middleware
{
    // This is our custom middleware class. It acts like a checkpoint gate in the pipeline.
    public class CustomMiddlewareDemo
    {
        private readonly RequestDelegate _next;

        // The constructor takes the 'next' middleware delegate.
        // This is a reference to the next checkpoint down the conveyor belt.
        public CustomMiddlewareDemo(RequestDelegate next)
        {
            _next = next;
        }

        // This method gets called automatically by ASP.NET Core whenever a request passes by.
        public async Task InvokeAsync(HttpContext context)
        {
            // Printing to the terminal when a browser request comes in
            Console.WriteLine("Request received...!!!");

            // Passing the request to the next piece of middleware in the line
            await _next(context);

            // Printing to the terminal right as the response goes back out to the user
            Console.WriteLine("Response Sent...!!");
        }
    }
}
