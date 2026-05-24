using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureReliableUserManagement.Services
{
    /// <summary>
    /// Cryptographic service providing symmetric AES-256 encryption and decryption.
    /// 
    /// NOTE FOR STUDENTS: Real production systems must store encryption keys securely 
    /// using specialized Key Vault Services (e.g. Azure Key Vault, AWS KMS) rather than 
    /// embedding them in source code.
    /// </summary>
    public class EncryptionService
    {
        // Simple fixed key and IV arrays to satisfy requirements without complex file management.
        // A 32-byte key for AES-256 and a 16-byte initialization vector (IV).
        private readonly byte[] _key = new byte[32] 
        {
            0x1A, 0x2B, 0x3C, 0x4D, 0x5E, 0x6F, 0x70, 0x81,
            0x92, 0xA3, 0xB4, 0xC5, 0xD6, 0xE7, 0xF8, 0x09,
            0x10, 0x21, 0x32, 0x43, 0x54, 0x65, 0x76, 0x87,
            0x98, 0xA9, 0xB0, 0xC1, 0xD2, 0xE3, 0xF4, 0x55
        };

        private readonly byte[] _iv = new byte[16]
        {
            0xF1, 0xE2, 0xD3, 0xC4, 0xB5, 0xA6, 0x97, 0x88,
            0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00
        };

        /// <summary>
        /// Encrypts a plain-text string into a Base64-encoded cipher text using AES.
        /// </summary>
        public string Encrypt(string plainText)
        {
            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(inputBytes, 0, inputBytes.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts a Base64-encoded AES cipher text back into plain text.
        /// </summary>
        public string Decrypt(string encryptedText)
        {
            if (encryptedText == null)
            {
                throw new ArgumentNullException(nameof(encryptedText));
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        byte[] cipherBytes = Convert.FromBase64String(encryptedText);
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
