using System;

namespace SecureReliableUserManagement.Models
{
    /// <summary>
    /// Represents a registered user containing hashed credentials and encrypted details.
    /// </summary>
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string EncryptedDetails { get; set; } = string.Empty;

        public User(string username, string hashedPassword, string encryptedDetails)
        {
            Username = username;
            HashedPassword = hashedPassword;
            EncryptedDetails = encryptedDetails;
        }
    }
}
