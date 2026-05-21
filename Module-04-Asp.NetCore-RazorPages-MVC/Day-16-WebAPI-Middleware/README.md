# Day 16: Web API and Middleware Basics

## Daily Summary
Today we explored the fundamentals of building Web APIs in ASP.NET Core and how the HTTP request pipeline works. 

An ASP.NET Core Web API project is structured around controllers. The entry point of our application configures the request conveyor belt (pipeline), and then controllers handle specific endpoints. 

For example, the default out-of-the-box `WeatherForecastController` is an API endpoint that listens for web requests. When we visit `/weatherforecast`, it processes the call and returns clean, structured **JSON objects** over a successful **HTTP status code 200** (which means "OK"). This allows client front-end apps (like Angular or React) to read the data easily and format it for the user.

---

## File Contents in this Folder

*   [Web_Framework_Evolution.md](./Web_Framework_Evolution.md): Study guide notes explaining client vs. server concepts, how Microsoft web tools evolved to modern JSON-based cross-platform APIs, and how the middleware conveyor belt processes requests and responses.
*   [CustomMiddlewareDemo.cs](./CustomMiddlewareDemo.cs): A clean, simple C# custom middleware class showing how to intercept request and response streams to print trace messages to the console.

---

## Portfolio Context

*   **Repository Location**: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
*   **Module**: Module 04 (ASP.NET Core Web Applications)
*   **Target Scope**: Day 16 - Web API & Middleware Fundamentals
