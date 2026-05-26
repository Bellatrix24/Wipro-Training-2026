using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SecureTaskManagementPlatform.Services
{
    public class ClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasClaim(string claimType, string claimValue)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.HasClaim(claimType, claimValue) ?? false;
        }

        public bool CanEditTask()
        {
            return HasClaim("CanEditTask", "true");
        }
    }
}
