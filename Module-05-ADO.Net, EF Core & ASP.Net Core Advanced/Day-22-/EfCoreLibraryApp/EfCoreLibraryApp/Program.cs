using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EfCoreLibraryApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register Code First context with InMemory database
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseInMemoryDatabase("LibraryCodeFirstDb"));

// Register Database First context with InMemory database
builder.Services.AddDbContext<DbFirstLibraryContext>(options =>
    options.UseInMemoryDatabase("LibraryDbFirstDb"));

var app = builder.Build();

// Seed the databases on startup
using (var scope = app.Services.CreateScope())
{
    var codeFirstDb = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    codeFirstDb.Database.EnsureCreated();

    var dbFirstDb = scope.ServiceProvider.GetRequiredService<DbFirstLibraryContext>();
    dbFirstDb.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
