using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidDesignPatterns.SOLID.Formatters;
using SolidDesignPatterns.SOLID.Interfaces;
using SolidDesignPatterns.SOLID.Models;
using SolidDesignPatterns.SOLID.Services;

namespace SolidDesignPatterns.Tests
{
    [TestClass]
    public class SolidPrinciplesTests
    {
        private const string TestFileName = "test-report-output.txt";
        
        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                if (File.Exists(TestFileName))
                {
                    File.Delete(TestFileName);
                }
            }
            catch
            {
                // Suppressed to ensure tests run cleanly
            }
        }

        [TestMethod]
        public void ReportGenerator_GeneratesReportContent()
        {
            // Arrange
            var generator = new ReportGenerator();
            var report = new SalesReport("Annual Sales", "Q4 closed strongly.", 150000.0);

            // Act
            string rawContent = generator.Generate(report);

            // Assert
            Assert.IsNotNull(rawContent);
            Assert.IsTrue(rawContent.Contains("Annual Sales"));
            Assert.IsTrue(rawContent.Contains("Q4 closed strongly."));
        }

        [TestMethod]
        public void ReportSaver_SavesReportContent()
        {
            // Arrange
            var saver = new ReportSaver();
            string content = "Sample test report payload.";

            // Act
            bool result = saver.Save(content, TestFileName);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(TestFileName));
            string savedContent = File.ReadAllText(TestFileName);
            Assert.AreEqual(content, savedContent);
        }

        [TestMethod]
        public void PdfFormatter_FormatsReportAsPdf()
        {
            // Arrange
            var formatter = new PdfReportFormatter();
            var report = new SalesReport("Sales Q4", "Very positive.", 5000.0);

            // Act
            string formattedText = formatter.Format(report);

            // Assert
            Assert.IsTrue(formattedText.Contains("[PDF FORMAT]"));
            Assert.IsTrue(formattedText.Contains("SALES Q4"));
        }

        [TestMethod]
        public void ExcelFormatter_FormatsReportAsExcel()
        {
            // Arrange
            var formatter = new ExcelReportFormatter();
            var report = new InventoryReport("Stock 2026", "Healthy count.", 250);

            // Act
            string formattedText = formatter.Format(report);

            // Assert
            Assert.IsTrue(formattedText.Contains("[EXCEL FORMAT]"));
            Assert.IsTrue(formattedText.Contains("\"Stock 2026\""));
        }

        [TestMethod]
        public void SalesReport_CanBeUsedAsBaseReport()
        {
            // Arrange
            Report report = new SalesReport("Sales LSP", "Consistent performance.", 88000.0);

            // Act
            string summary = report.GetSummary();

            // Assert: Safe substitutability verification (LSP)
            Assert.IsTrue(summary.Contains("Sales Report Summary"));
            Assert.IsTrue(summary.Contains("88,000"));
        }

        [TestMethod]
        public void InventoryReport_CanBeUsedAsBaseReport()
        {
            // Arrange
            Report report = new InventoryReport("Inventory LSP", "Low stocks warning.", 15);

            // Act
            string summary = report.GetSummary();

            // Assert: Safe substitutability verification (LSP)
            Assert.IsTrue(summary.Contains("Inventory Report Summary"));
            Assert.IsTrue(summary.Contains("15"));
        }

        [TestMethod]
        public void ReportService_UsesInjectedDependencies()
        {
            // Arrange
            var mockGenerator = new FakeReportGenerator();
            var mockFormatter = new FakeReportFormatter();
            var mockSaver = new FakeReportSaver();
            var service = new ReportService(mockGenerator, mockFormatter, mockSaver);
            var report = new SalesReport("Title", "Content", 10.0);

            // Act
            service.CreateAndSaveReport(report, TestFileName);

            // Assert: Verify dependencies were invoked
            Assert.IsTrue(mockGenerator.WasInvoked);
            Assert.IsTrue(mockFormatter.WasInvoked);
            Assert.IsTrue(mockSaver.WasInvoked);
        }

        [TestMethod]
        public void ReportService_CreateAndSaveReport_ReturnsTrue()
        {
            // Arrange
            var generator = new ReportGenerator();
            var formatter = new PdfReportFormatter();
            var saver = new ReportSaver();
            var service = new ReportService(generator, formatter, saver);
            var report = new SalesReport("Integration Title", "Integration Content", 22000.0);

            // Act
            bool result = service.CreateAndSaveReport(report, TestFileName);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(TestFileName));
        }

        // ==========================================
        // FAKE MOCK CLASSES FOR ISOLATED BEHAVIOR TESTING
        // ==========================================
        
        private class FakeReportGenerator : IReportGenerator
        {
            public bool WasInvoked { get; private set; }
            public string Generate(Report report)
            {
                WasInvoked = true;
                return "Fake Content";
            }
        }

        private class FakeReportFormatter : IReportFormatter
        {
            public bool WasInvoked { get; private set; }
            public string Format(Report report)
            {
                WasInvoked = true;
                return "Fake Formatted Report";
            }
        }

        private class FakeReportSaver : IReportSaver
        {
            public bool WasInvoked { get; private set; }
            public bool Save(string content, string fileName)
            {
                WasInvoked = true;
                return true;
            }
        }
    }
}
