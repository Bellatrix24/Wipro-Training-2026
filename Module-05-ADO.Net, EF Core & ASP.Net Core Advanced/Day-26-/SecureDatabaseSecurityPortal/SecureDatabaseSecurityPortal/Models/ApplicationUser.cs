using Microsoft.AspNetCore.Identity;

namespace SecureDatabaseSecurityPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
