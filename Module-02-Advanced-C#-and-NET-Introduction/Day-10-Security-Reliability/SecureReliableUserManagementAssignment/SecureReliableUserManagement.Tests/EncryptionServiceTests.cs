using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureReliableUserManagement.Services;

namespace SecureReliableUserManagement.Tests
{
    [TestClass]
    public class EncryptionServiceTests
    {
        private EncryptionService _encryptionService = null!;
        private const string PlainText = "Extremely Sensitive Training Details 123!";

        [TestInitialize]
        public void Setup()
        {
            _encryptionService = new EncryptionService();
        }

        [TestMethod]
        public void Encrypt_ReturnsDifferentTextThanOriginal()
        {
            // Act
            string cipherText = _encryptionService.Encrypt(PlainText);

            // Assert
            Assert.IsNotNull(cipherText);
            Assert.AreNotEqual(PlainText, cipherText);
            // Verify it is a valid base64 string format
            Assert.IsTrue(IsBase64String(cipherText));
        }

        [TestMethod]
        public void Decrypt_ReturnsOriginalText()
        {
            // Arrange
            string cipherText = _encryptionService.Encrypt(PlainText);

            // Act
            string decryptedText = _encryptionService.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(PlainText, decryptedText);
        }

        private bool IsBase64String(string s)
        {
            Span<byte> buffer = new Span<byte>(new byte[s.Length]);
            return Convert.TryFromBase64String(s, buffer, out _);
        }
    }
}
