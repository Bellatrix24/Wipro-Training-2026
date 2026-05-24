using System;

namespace SolidDesignPatterns.DesignPatterns.Factory
{
    /// <summary>
    /// Abstract product interface for Document Factory pattern.
    /// </summary>
    public interface IDocument
    {
        string Title { get; }
        
        string GetDocumentType();
    }
}
