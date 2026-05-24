using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureReliableUserManagement.Models;
using SecureReliableUserManagement.Services;

namespace SecureReliableUserManagement.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService = null!;
        private const string TestUsername = "john_doe";
        private const string TestPassword = "SecurePassword123!";
        private const string TestDetails = "Credit Card: 1111-2222-3333-4444";

        [TestInitialize]
        public void Setup()
        {
            _userService = new UserService();
        }

        [TestMethod]
        public void Register_WithValidUser_ReturnsTrue()
        {
            // Act
            bool result = _userService.Register(TestUsername, TestPassword, TestDetails);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(_userService.GetUserForTest(TestUsername));
        }

        [TestMethod]
        public void Register_HashesPasswordBeforeStoring()
        {
            // Arrange
            _userService.Register(TestUsername, TestPassword, TestDetails);

            // Act
            User? user = _userService.GetUserForTest(TestUsername);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreNotEqual(TestPassword, user.HashedPassword);
            Assert.AreEqual(64, user.HashedPassword.Length); // SHA-256 hex output is 64 characters
        }

        [TestMethod]
        public void Register_WithDuplicateUsername_ReturnsFalse()
        {
            // Arrange
            _userService.Register(TestUsername, TestPassword, TestDetails);

            // Act: Attempt to register same username
            bool duplicateResult = _userService.Register(TestUsername, "AnotherPassword", "Other details");

            // Assert
            Assert.IsFalse(duplicateResult);
        }

        [TestMethod]
        public void Register_WithEmptyUsername_ReturnsFalse()
        {
            // Act
            bool emptyUsernameResult = _userService.Register("   ", TestPassword, TestDetails);
            bool nullUsernameResult = _userService.Register(null!, TestPassword, TestDetails);

            // Assert
            Assert.IsFalse(emptyUsernameResult);
            Assert.IsFalse(nullUsernameResult);
        }

        [TestMethod]
        public void Authenticate_WithCorrectPassword_ReturnsTrue()
        {
            // Arrange
            _userService.Register(TestUsername, TestPassword, TestDetails);

            // Act
            bool result = _userService.Authenticate(TestUsername, TestPassword);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Authenticate_WithWrongPassword_ReturnsFalse()
        {
            // Arrange
            _userService.Register(TestUsername, TestPassword, TestDetails);

            // Act
            bool result = _userService.Authenticate(TestUsername, "WrongPassword");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetDecryptedDetails_ReturnsOriginalDetails()
        {
            // Arrange
            _userService.Register(TestUsername, TestPassword, TestDetails);

            // Act
            string decryptedResult = _userService.GetDecryptedDetails(TestUsername);

            // Assert
            Assert.AreEqual(TestDetails, decryptedResult);
        }

        [TestMethod]
        public void GetDecryptedDetails_WithMissingUser_ReturnsEmptyString()
        {
            // Act: Get details for username that was never registered
            string result = _userService.GetDecryptedDetails("non_existent_user");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}
