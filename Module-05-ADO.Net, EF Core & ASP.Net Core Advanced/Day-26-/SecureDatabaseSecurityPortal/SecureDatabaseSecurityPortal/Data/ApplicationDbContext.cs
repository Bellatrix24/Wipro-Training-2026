using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureDatabaseSecurityPortal.Models;

namespace SecureDatabaseSecurityPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerRecord> CustomerRecords { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
