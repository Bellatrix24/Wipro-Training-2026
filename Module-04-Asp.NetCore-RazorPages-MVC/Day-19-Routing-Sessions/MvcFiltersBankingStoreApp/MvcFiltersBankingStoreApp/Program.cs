using MvcFiltersBankingStoreApp.Filters;
using MvcFiltersBankingStoreApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register application services (in-memory singletons to persist logs across requests)
builder.Services.AddSingleton<LoggingService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<UserRoleService>();

// Register controllers and configure global filters
builder.Services.AddControllersWithViews(options =>
{
    // Apply request logging globally to track all requests
    options.Filters.Add<RequestLoggingFilter>();
    
    // Apply global exception filter to catch and log all unhandled runtime errors
    options.Filters.Add<GlobalExceptionFilter>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default home catalog routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
