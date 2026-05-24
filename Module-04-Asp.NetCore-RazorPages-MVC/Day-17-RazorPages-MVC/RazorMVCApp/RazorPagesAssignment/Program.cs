var builder = WebApplication.CreateBuilder(args);

// Natural comment: Add services to the container. We need Razor Pages for this project.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Natural comment: Modern ASP.NET Core uses Program.cs instead of Startup.cs for middleware and route configurations.
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
