using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookstoreApp.Filters;
using OnlineBookstoreApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Note: Modern ASP.NET Core applications use Program.cs as a unified entry point, replacing the old Startup.cs system.

// Register in-memory repositories as singletons to persist book and account data across requests
builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

// Configure and register session services required for shopping cart persistence and mock logins
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure MVC controllers with globally registered custom logging, error, and session validation filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LoggingFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<SessionValidationFilter>();
});

// Register Razor Pages services
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session state (must be placed before authentication and authorization middleware)
app.UseSession();
app.UseAuthorization();

// 1. MVC Custom Routes with Constraints
app.MapControllerRoute(
    name: "booksIndex",
    pattern: "Books",
    defaults: new { controller = "Books", action = "Index" });

app.MapControllerRoute(
    name: "booksDetails",
    pattern: "Books/Details/{id:int}",
    defaults: new { controller = "Books", action = "Details" });

app.MapControllerRoute(
    name: "ordersSummary",
    pattern: "Orders/Summary",
    defaults: new { controller = "Orders", action = "Summary" });

app.MapControllerRoute(
    name: "ordersConfirmation",
    pattern: "Orders/Confirmation/{id:int}",
    defaults: new { controller = "Orders", action = "Confirmation" });

// Fallback MVC route pointing to BooksController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

// 2. Map Razor Pages (natively handles Inventory, Cart, and Account directory structures)
app.MapRazorPages();

app.Run();
