using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecureJwtAuthApi.Models;

namespace SecureJwtAuthApi.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public (string Token, DateTime Expiry) GenerateToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim("FullName", user.FullName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "SuperSecretAndSecureDefaultKeyForTestingPurposes"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var expiryMinutes = double.Parse(_config["Jwt:ExpiryMinutes"] ?? "30");
            var expiry = DateTime.Now.AddMinutes(expiryMinutes);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"] ?? "SecureJwtAuthApiIssuer",
                audience: _config["Jwt:Audience"] ?? "SecureJwtAuthApiAudience",
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiry);
        }
    }
}
