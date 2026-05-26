using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AdoNetBookstoreApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Note: Modern ASP.NET Core applications use Program.cs as a unified entry point, replacing the old Startup.cs system.

// Register the ADO.NET Data Access Layer class in dependency injection
builder.Services.AddScoped<BookDataAccess>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default home catalog routing pointing to BooksController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
