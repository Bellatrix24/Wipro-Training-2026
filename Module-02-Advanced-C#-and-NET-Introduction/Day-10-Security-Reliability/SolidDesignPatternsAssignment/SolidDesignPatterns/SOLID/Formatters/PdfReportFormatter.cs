using System;
using SolidDesignPatterns.SOLID.Interfaces;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Formatters
{
    /// <summary>
    /// Formats a report into PDF style.
    /// Demonstrates SRP and OCP: Only responsible for PDF formatting.
    /// </summary>
    public class PdfReportFormatter : IReportFormatter
    {
        public string Format(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            return $"--- [PDF FORMAT] ---\n" +
                   $"Title: {report.Title.ToUpper()}\n" +
                   $"Summary: {report.GetSummary()}\n" +
                   $"---------------------";
        }
    }
}
