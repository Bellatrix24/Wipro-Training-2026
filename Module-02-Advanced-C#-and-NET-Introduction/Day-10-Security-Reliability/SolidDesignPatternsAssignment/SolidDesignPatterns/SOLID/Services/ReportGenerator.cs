using System;
using SolidDesignPatterns.SOLID.Interfaces;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Services
{
    /// <summary>
    /// Implements SRP: Dedicated solely to generating raw report text.
    /// </summary>
    public class ReportGenerator : IReportGenerator
    {
        public string Generate(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            return $"Generated Content for '{report.Title}': {report.Content}";
        }
    }
}
