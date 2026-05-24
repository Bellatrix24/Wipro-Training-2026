using System;

namespace SolidDesignPatterns.DesignPatterns.Factory
{
    /// <summary>
    /// Concrete PDF document product.
    /// </summary>
    public class PdfDocument : IDocument
    {
        public string Title { get; }

        public PdfDocument(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public string GetDocumentType()
        {
            return "PDF";
        }
    }
}
