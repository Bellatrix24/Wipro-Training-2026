namespace SecureDatabaseSecurityPortal.Models
{
    public class CustomerRecord
    {
        public int RecordId { get; set; }
        public string FullName { get; set; } = string.Empty;
        
        // Demonstrates stored encrypted sensitive data (e.g. encrypted TaxId)
        public string EncryptedTaxId { get; set; } = string.Empty;

        // Demonstrates HMAC integrity signature validating the sensitive data against tampering
        public string TaxIdHmac { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
