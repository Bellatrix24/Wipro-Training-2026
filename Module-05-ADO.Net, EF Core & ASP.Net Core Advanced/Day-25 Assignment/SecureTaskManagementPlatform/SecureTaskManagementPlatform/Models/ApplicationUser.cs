using Microsoft.AspNetCore.Identity;

namespace SecureTaskManagementPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
