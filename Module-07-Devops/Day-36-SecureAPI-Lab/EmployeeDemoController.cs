using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SecureAPI.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class EmployeeDemoController : ControllerBase
    {
        // Trainee Study Reminder: For local testing, we are using this hardcoded symmetric key.
        // In a real application, we would pull this value from appsettings.json!
        private const string SecretKey = "SuperSecretKeyForWiproTraining2026TokenVerificationDoubleLengthSecurityKey!";

        // POST: /api/demo/login
        // This endpoint takes a username and password, validates them, and hands back a JWT.
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Simple mock validation for today's lab
            if (request.Username == "wipro_trainee" && request.Password == "secure123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.Role, "Employee"),
                    new Claim("Department", "Engineering")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Build and sign our JWT identity card
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenString, ExpiresInMinutes = 30 });
            }

            return Unauthorized(new { Message = "Oops! Invalid username or password." });
        }

        // GET: /api/demo/data
        // The [Authorize] attribute below acts like an automated security guard. 
        // Before the code inside this method runs, the middleware interceptor intercepts the request,
        // checks the Authorization header for a bearer token, and validates the signature.
        // If the token is missing or messed up, the server will kick back a 401 Unauthorized instantly.
        [Authorize]
        [HttpGet("data")]
        public IActionResult GetData()
        {
            var employeeData = new[]
            {
                new { Id = 1, Name = "Alice Smith", Role = "Senior Engineer", SalaryBand = "Level 3" },
                new { Id = 2, Name = "Bob Jones", Role = "System Architect", SalaryBand = "Level 4" }
            };

            return Ok(new
            {
                Message = "Access Granted! Confidentially queried employee database records.",
                Data = employeeData
            });
        }
    }

    // Small data transfer object (DTO) class for login requests
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
