using System;
using System.Security.Cryptography;

namespace SecureDatabaseSecurityPortal.Security
{
    public static class PasswordSecurityHelper
    {
        // Demonstrates standard PBKDF2 secure password hashing using SHA256 with 100,000 iterations
        public static string HashPasswordPbkdf2(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(16); // Cryptographically strong 128-bit salt
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA256, 32);

            var hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }

        // Verifies password against PBKDF2 hashed value
        public static bool VerifyPasswordPbkdf2(string password, string hashedPassword)
        {
            try
            {
                var hashBytes = Convert.FromBase64String(hashedPassword);
                var salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA256, 32);

                // Use constant-time comparison to prevent timing attacks
                var diff = 0;
                for (int i = 0; i < 32; i++)
                {
                    diff |= hashBytes[i + 16] ^ hash[i];
                }
                return diff == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
