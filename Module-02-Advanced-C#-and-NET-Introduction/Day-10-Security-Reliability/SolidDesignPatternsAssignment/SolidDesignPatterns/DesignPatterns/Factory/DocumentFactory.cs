using System;

namespace SolidDesignPatterns.DesignPatterns.Factory
{
    /// <summary>
    /// Document Factory class demonstrating the Factory Method pattern.
    /// Creates documents based on string keys, isolating instantiation logic from clients.
    /// </summary>
    public class DocumentFactory
    {
        /// <summary>
        /// Instantiates and returns concrete products implementing IDocument.
        /// Throws ArgumentException for unknown types.
        /// </summary>
        public IDocument CreateDocument(string documentType, string title)
        {
            if (string.IsNullOrWhiteSpace(documentType))
            {
                throw new ArgumentException("Document type cannot be empty.", nameof(documentType));
            }

            string typeNormalized = documentType.Trim().ToLowerInvariant();

            switch (typeNormalized)
            {
                case "pdf":
                    return new PdfDocument(title);
                case "word":
                    return new WordDocument(title);
                default:
                    throw new ArgumentException($"Unsupported document type: '{documentType}'. Only 'pdf' and 'word' are supported.");
            }
        }
    }
}
