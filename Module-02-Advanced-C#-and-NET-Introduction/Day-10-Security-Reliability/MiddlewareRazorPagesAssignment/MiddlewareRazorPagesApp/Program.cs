using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// ==========================================
// CUSTOM MIDDLEWARE CONFIGURATION (ASSIGNMENT 1)
// ==========================================

// 1. Custom Request/Response Logging Middleware
// Logs the HTTP Method and Path for incoming requests, and the Status Code for outgoing responses.
app.Use(async (context, next) =>
{
    // Log incoming details
    Console.WriteLine($"[LOG] Incoming Request: {context.Request.Method} {context.Request.Path}");

    await next();

    // Log outgoing details
    Console.WriteLine($"[LOG] Outgoing Response: {context.Response.StatusCode} for {context.Request.Path}");
});

// 2. Content Security Policy (CSP) Custom Middleware
// This header reduces Cross-Site Scripting (XSS) risks by restricting resources
// (scripts, styles, etc.) to only be loaded from local ('self') sources.
app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; script-src 'self'; style-src 'self';";
    await next();
});

// ==========================================
// STANDARD MIDDLEWARE & PIPELINE
// ==========================================

// 3. Error handling middleware (graceful redirection to user-friendly /Error page)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Even in development, we can test /Error page behaviors
    app.UseExceptionHandler("/Error");
}

// 4. HTTPS enforcement
app.UseHttpsRedirection();

// 5. Static files serving (enables wwwroot/ folder)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
