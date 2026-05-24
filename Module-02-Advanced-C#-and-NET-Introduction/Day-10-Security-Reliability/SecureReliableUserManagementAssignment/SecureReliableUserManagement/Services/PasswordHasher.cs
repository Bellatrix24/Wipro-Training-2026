using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureReliableUserManagement.Services
{
    /// <summary>
    /// Cryptographic hashing service using SHA-256 algorithm.
    /// Note: Production systems should use slow-hashing algorithms with unique random salts like BCrypt or PBKDF2.
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// Hashes a plain-text password using SHA-256 and returns a lowercase hex string representation.
        /// </summary>
        public string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifies a plain-text password against a pre-computed SHA-256 hash.
        /// </summary>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (password == null || hashedPassword == null)
            {
                return false;
            }

            string computedHash = HashPassword(password);
            return string.Equals(computedHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
