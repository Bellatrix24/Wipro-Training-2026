using System;
using System.Collections.Generic;
using System.Linq;
using SecureReliableUserManagement.Models;

namespace SecureReliableUserManagement.Services
{
    /// <summary>
    /// Coordinates user registration, authentication, and sensitive data access securely.
    /// Incorporates in-memory storage, encryption, password hashing, and logging.
    /// </summary>
    public class UserService
    {
        private readonly List<User> _users = new List<User>();
        private readonly PasswordHasher _hasher = new PasswordHasher();
        private readonly EncryptionService _encryption = new EncryptionService();
        private readonly FileLogger _logger = new FileLogger();

        /// <summary>
        /// Registers a new user. Performs validation, hashing, and details encryption.
        /// </summary>
        public bool Register(string username, string password, string sensitiveDetails)
        {
            try
            {
                // 1. Validation for empty inputs
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    _logger.LogInfo("Registration failed: Username or password cannot be empty.");
                    return false;
                }

                // 2. Validation for duplicate username
                if (_users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)))
                {
                    _logger.LogInfo($"Registration failed: Username '{username}' already exists.");
                    return false;
                }

                // 3. Cryptographic Operations: Hash password and encrypt sensitive details
                string hashedPassword = _hasher.HashPassword(password);
                string encryptedDetails = _encryption.Encrypt(sensitiveDetails ?? string.Empty);

                // 4. Persistence in memory
                var newUser = new User(username, hashedPassword, encryptedDetails);
                _users.Add(newUser);

                // 5. Audit Logging (Do not log passwords or raw details!)
                _logger.LogInfo($"User '{username}' registered successfully.");
                return true;
            }
            catch (Exception ex)
            {
                // Graceful error handling: Log exception details but do not leak them to caller
                _logger.LogError($"Exception occurred during registration for user '{username}'.", ex);
                return false;
            }
        }

        /// <summary>
        /// Authenticates user credentials using secure password verification.
        /// </summary>
        public bool Authenticate(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    _logger.LogInfo("Authentication failed: Username or password cannot be empty.");
                    return false;
                }

                var user = _users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    _logger.LogInfo($"Authentication failed: User '{username}' not found.");
                    return false;
                }

                // Verify the hashed password
                bool isValid = _hasher.VerifyPassword(password, user.HashedPassword);
                if (isValid)
                {
                    _logger.LogInfo($"User '{username}' logged in successfully.");
                    return true;
                }
                else
                {
                    _logger.LogInfo($"Authentication failed: Wrong password for user '{username}'.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred during authentication for user '{username}'.", ex);
                return false;
            }
        }

        /// <summary>
        /// Retrieves and decrypts the sensitive details associated with the user.
        /// </summary>
        public string GetDecryptedDetails(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return string.Empty;
                }

                var user = _users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    _logger.LogInfo($"GetDecryptedDetails failed: User '{username}' does not exist.");
                    return string.Empty;
                }

                // Decrypt the details back to original plain text
                string decryptedText = _encryption.Decrypt(user.EncryptedDetails);
                _logger.LogInfo($"User '{username}' sensitive details decrypted and accessed successfully.");
                return decryptedText;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while getting decrypted details for user '{username}'.", ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Helper method to retrieve raw user for test validations (like checking if password is saved hashed).
        /// </summary>
        public User? GetUserForTest(string username)
        {
            return _users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
