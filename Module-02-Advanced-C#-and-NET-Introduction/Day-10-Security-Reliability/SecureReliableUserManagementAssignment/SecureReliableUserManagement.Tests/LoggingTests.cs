using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureReliableUserManagement.Services;

namespace SecureReliableUserManagement.Tests
{
    [TestClass]
    public class LoggingTests
    {
        private FileLogger _logger = null!;
        private const string LogFileName = "app-log.txt";

        [TestInitialize]
        public void Setup()
        {
            _logger = new FileLogger();
            CleanLogFile();
        }

        [TestCleanup]
        public void Cleanup()
        {
            CleanLogFile();
        }

        [TestMethod]
        public void LogInfo_WritesMessageToFile()
        {
            // Arrange
            string uniqueMessage = $"Test INFO Log Entry: {Guid.NewGuid()}";

            // Act
            _logger.LogInfo(uniqueMessage);

            // Assert
            Assert.IsTrue(File.Exists(LogFileName));
            string fileContent = File.ReadAllText(LogFileName);
            Assert.IsTrue(fileContent.Contains("[INFO]"));
            Assert.IsTrue(fileContent.Contains(uniqueMessage));
        }

        [TestMethod]
        public void LogError_WritesErrorToFile()
        {
            // Arrange
            string errorMessage = $"Test ERROR Log Entry: {Guid.NewGuid()}";
            var testException = new InvalidOperationException("Simulation of an app error.");

            // Act
            _logger.LogError(errorMessage, testException);

            // Assert
            Assert.IsTrue(File.Exists(LogFileName));
            string fileContent = File.ReadAllText(LogFileName);
            Assert.IsTrue(fileContent.Contains("[ERROR]"));
            Assert.IsTrue(fileContent.Contains(errorMessage));
            Assert.IsTrue(fileContent.Contains(testException.GetType().FullName!));
            Assert.IsTrue(fileContent.Contains(testException.Message));
        }

        private void CleanLogFile()
        {
            try
            {
                if (File.Exists(LogFileName))
                {
                    File.Delete(LogFileName);
                }
            }
            catch
            {
                // Suppress to prevent cleanup failures from failing tests
            }
        }
    }
}
