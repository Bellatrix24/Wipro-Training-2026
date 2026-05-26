using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SecureDatabaseSecurityPortal.Services
{
    public class HmacService
    {
        private readonly string _aesKey;
        private readonly string _hmacKey;

        public HmacService(IConfiguration config)
        {
            // Read keys from config or fall back to safe defaults for the demo
            _aesKey = config["Security:AesKey"] ?? "AESSecretKeyForDatabasePortal2026";
            _hmacKey = config["Security:HmacKey"] ?? "HMACSecretKeyForDatabasePortal2026";
        }

        // Computes SHA256 HMAC for data integrity
        public string ComputeHmac(string data)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_hmacKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hashBytes);
        }

        // Verifies the HMAC signature to check if data was tampered with
        public bool VerifyHmac(string data, string originalHmac)
        {
            var calculated = ComputeHmac(data);
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromBase64String(calculated),
                Convert.FromBase64String(originalHmac));
        }

        // Simple AES encryption for protecting sensitive fields
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;

            var keyBytes = Encoding.UTF8.GetBytes(_aesKey.PadRight(32).Substring(0, 32));
            var ivBytes = Encoding.UTF8.GetBytes(_aesKey.PadRight(16).Substring(0, 16));

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        // Simple AES decryption
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return string.Empty;

            try
            {
                var cipherBytes = Convert.FromBase64String(cipherText);
                var keyBytes = Encoding.UTF8.GetBytes(_aesKey.PadRight(32).Substring(0, 32));
                var ivBytes = Encoding.UTF8.GetBytes(_aesKey.PadRight(16).Substring(0, 16));

                using var aes = Aes.Create();
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(cipherBytes);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);

                return sr.ReadToEnd();
            }
            catch
            {
                return "[Decryption Failure]";
            }
        }
    }
}
