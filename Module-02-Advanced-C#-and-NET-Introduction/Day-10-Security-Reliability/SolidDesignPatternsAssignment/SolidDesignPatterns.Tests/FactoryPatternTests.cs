using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidDesignPatterns.DesignPatterns.Factory;

namespace SolidDesignPatterns.Tests
{
    [TestClass]
    public class FactoryPatternTests
    {
        [TestMethod]
        public void DocumentFactory_CreatesPdfDocument()
        {
            // Arrange
            var factory = new DocumentFactory();

            // Act
            var doc = factory.CreateDocument("pdf", "My PDF Report");

            // Assert
            Assert.IsNotNull(doc);
            Assert.IsInstanceOfType(doc, typeof(PdfDocument));
            Assert.AreEqual("PDF", doc.GetDocumentType());
            Assert.AreEqual("My PDF Report", doc.Title);
        }

        [TestMethod]
        public void DocumentFactory_CreatesWordDocument()
        {
            // Arrange
            var factory = new DocumentFactory();

            // Act
            var doc = factory.CreateDocument("word", "My Word Doc");

            // Assert
            Assert.IsNotNull(doc);
            Assert.IsInstanceOfType(doc, typeof(WordDocument));
            Assert.AreEqual("Word", doc.GetDocumentType());
            Assert.AreEqual("My Word Doc", doc.Title);
        }

        [TestMethod]
        public void DocumentFactory_WithInvalidType_ThrowsArgumentException()
        {
            // Arrange
            var factory = new DocumentFactory();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => factory.CreateDocument("powerpoint", "My Slide"));
        }

        [TestMethod]
        public void PdfAndWordDocuments_ImplementSameInterface()
        {
            // Arrange
            var factory = new DocumentFactory();

            // Act
            var pdfDoc = factory.CreateDocument("pdf", "PDF title");
            var wordDoc = factory.CreateDocument("word", "Word title");

            // Assert
            Assert.IsInstanceOfType(pdfDoc, typeof(IDocument));
            Assert.IsInstanceOfType(wordDoc, typeof(IDocument));
        }
    }
}
