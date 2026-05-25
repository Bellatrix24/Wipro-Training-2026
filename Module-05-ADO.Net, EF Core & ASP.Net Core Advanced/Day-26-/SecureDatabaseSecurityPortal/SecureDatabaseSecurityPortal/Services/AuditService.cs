using System;
using System.Threading.Tasks;
using SecureDatabaseSecurityPortal.Data;
using SecureDatabaseSecurityPortal.Models;

namespace SecureDatabaseSecurityPortal.Services
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;

        public AuditService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Audits access and modifications, marking suspicious events (e.g. failed authorizations)
        public async Task LogActionAsync(string email, string action, string details, bool isSuspicious)
        {
            var log = new AuditLog
            {
                UserEmail = string.IsNullOrEmpty(email) ? "Anonymous/Unauthenticated" : email,
                Action = action,
                Details = details,
                Timestamp = DateTime.Now,
                IsSuspicious = isSuspicious
            };

            // EF Core uses fully parameterized queries underneath to ensure SQL injection prevention
            _context.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
