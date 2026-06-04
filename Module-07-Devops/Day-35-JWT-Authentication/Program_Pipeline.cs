using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

// Trainee reference snippet for configuring JWT Bearer token authentication services
// in our application builder container.

var builder = WebApplication.CreateBuilder(args);

// --- 1. Fetching Configuration parameters ---
var jwtKey = builder.Configuration["JwtSettings:JwtKey"] ?? "FallbackSecretKeyThatIsTooShortForSecurityStandards!";
var issuer = builder.Configuration["JwtSettings:Issuer"] ?? "http://localhost:5000";
var audience = builder.Configuration["JwtSettings:Audience"] ?? "http://localhost:5000";

// --- 2. Registering JWT Bearer Services ---
// We configure JWT Bearer as the default authentication scheme for our web API.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        // The SymmetricSecurityKey uses the private string key we defined in appsettings.json to verify signatures.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddControllers();

var app = builder.Build();

// --- 3. Pipeline Sequencing ---
app.UseRouting();

// CRITICAL SECURITY NOTE:
// app.UseAuthentication() must explicitly execute before app.UseAuthorization()!
// 1. UseAuthentication: Inspects headers, parses the Bearer token, and populates the User context (Who is this?).
// 2. UseAuthorization: Checks if the verified user has permission/roles to access the requested resource (What can they do?).
// If you flip these, the application tries to evaluate access rules for an empty/unauthenticated identity context!
app.UseAuthentication(); 
app.UseAuthorization();  

app.MapControllers();

app.Run();
