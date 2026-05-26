using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureJwtAuthApi.DTOs;
using SecureJwtAuthApi.Models;
using SecureJwtAuthApi.Services;

namespace SecureJwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                // Default registrants get regular User role
                await _userManager.AddToRoleAsync(user, "User");
                
                return Ok(new AuthResponseDto
                {
                    IsSuccess = true,
                    Message = "Registration successful. Please log in.",
                    Email = user.Email
                });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return Unauthorized(new AuthResponseDto { IsSuccess = false, Message = "Invalid login credentials." });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var tokenData = _jwtTokenService.GenerateToken(user, roles);

                return Ok(new AuthResponseDto
                {
                    IsSuccess = true,
                    Message = "Login successful.",
                    Token = tokenData.Token,
                    Expiry = tokenData.Expiry,
                    Email = user.Email ?? string.Empty
                });
            }

            if (result.IsLockedOut)
            {
                return StatusCode(423, new AuthResponseDto { IsSuccess = false, Message = "This account is locked due to too many failed attempts. Try again in 5 minutes." });
            }

            // Simple rate limit delay
            await Task.Delay(1000);

            return Unauthorized(new AuthResponseDto { IsSuccess = false, Message = "Invalid login credentials." });
        }
    }
}
