// ============================================================================
// Simple starting program for our ASP.NET Core web application.
// ============================================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

// This sets up the web app builder
var builder = WebApplication.CreateBuilder(args);

// Building the app so it's ready to use
var app = builder.Build();

// A quick default page to test if the web server actually works
app.MapGet("/", () => "Hello! Our ASP.NET Core web server is running successfully!");

// This keeps our app running so it can listen for browser requests
app.Run();
