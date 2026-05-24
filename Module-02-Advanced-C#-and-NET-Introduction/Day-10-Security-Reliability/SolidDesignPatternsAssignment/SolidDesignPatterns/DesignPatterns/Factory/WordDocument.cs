using System;

namespace SolidDesignPatterns.DesignPatterns.Factory
{
    /// <summary>
    /// Concrete Word document product.
    /// </summary>
    public class WordDocument : IDocument
    {
        public string Title { get; }

        public WordDocument(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public string GetDocumentType()
        {
            return "Word";
        }
    }
}
