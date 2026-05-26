using System;

namespace SecureJwtAuthApi.DTOs
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
