using System;

namespace SecureDatabaseSecurityPortal.Models
{
    public class AuditLog
    {
        public int LogId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool IsSuspicious { get; set; }
    }
}
