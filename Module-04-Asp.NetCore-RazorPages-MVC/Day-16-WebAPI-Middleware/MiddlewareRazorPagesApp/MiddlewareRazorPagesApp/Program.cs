using MiddlewareRazorPagesApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. We need Razor Pages support.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Natural comment: In development mode, we still show the custom error page to test exceptions.
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Enforce secure HTTPS redirection
app.UseHttpsRedirection();

// Natural comment: In modern ASP.NET Core, all routing and pipeline middlewares are configured directly in Program.cs.
app.UseRouting();

// Inject custom security headers middleware (Content Security Policy)
app.UseMiddleware<SecurityHeadersMiddleware>();

// Inject custom request and response logging middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();

// Enable static file delivery from wwwroot (index.html, css/site.css, js/site.js)
app.UseStaticFiles();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
