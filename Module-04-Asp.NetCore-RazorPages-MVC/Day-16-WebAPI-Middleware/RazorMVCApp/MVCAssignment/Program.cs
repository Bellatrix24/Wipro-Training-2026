var builder = WebApplication.CreateBuilder(args);

// Add services to the container. We need MVC controller support.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Natural comment: Modern ASP.NET Core uses Program.cs instead of Startup.cs to configure route pipelines and middleware.
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Map default controller route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
