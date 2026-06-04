using Microsoft.AspNetCore.Authentication.Cookies;

// Hey, this is a quick reference snippet showing how to register and sequence our security middleware in Program.cs.
// I keep this here as a cheat sheet so I don't mix up the pipeline order!

var builder = WebApplication.CreateBuilder(args);

// --- 1. Service Registration ---
// We tell ASP.NET Core that we want to use Cookie Authentication. 
// This registers the necessary auth services into the dependency injection (DI) container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Student Note: Securing our authentication cookies against hijacking!
        options.Cookie.HttpOnly = true; // This blocks JavaScript from reading the cookie (protects us from XSS cookie-theft).
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Forces the cookie to only be transmitted over HTTPS.
        options.Cookie.SameSite = SameSiteMode.Lax; // Mitigates Cross-Site Request Forgery (CSRF) attacks.
        
        options.LoginPath = "/Account/Login"; // Where we send users if they aren't logged in.
        options.AccessDeniedPath = "/Account/AccessDenied"; // Where we redirect users if they don't have the right permissions.
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- 2. Middleware Pipeline Sequencing ---
// The execution order of middleware in ASP.NET Core is super critical! 
// If we mess up the sequence, security checks might be skipped entirely.

app.UseStaticFiles();

app.UseRouting(); // First, figure out where the request is trying to go.

// WARNING: DO NOT FLIP THE ORDER OF THE TWO MIDDLEWARE BELOW!
// If UseAuthorization runs before UseAuthentication, it will try to check permissions
// for an anonymous/unidentified user, meaning our security rules won't work and the app will break.

app.UseAuthentication(); // 1. Identify the user. (Acts like a bouncer checking the ID card at the entrance: "Who are you?")
app.UseAuthorization();  // 2. Check their permissions. (Checks the ticket details: "What are you allowed to do?")

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
