using System;
using SolidDesignPatterns.SOLID.Interfaces;

namespace SolidDesignPatterns.SOLID.Models
{
    /// <summary>
    /// Base class representing a general report.
    /// Demonstrates LSP: Code expecting this class can safely substitute derived classes.
    /// </summary>
    public abstract class Report : IReportContent
    {
        public string Title { get; set; }
        public string Content { get; set; }

        protected Report(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public abstract string GetSummary();
    }
}
