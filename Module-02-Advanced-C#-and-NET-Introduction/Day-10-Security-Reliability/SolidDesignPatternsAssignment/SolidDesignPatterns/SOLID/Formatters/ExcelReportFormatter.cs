using System;
using SolidDesignPatterns.SOLID.Interfaces;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Formatters
{
    /// <summary>
    /// Formats a report into Excel style (CSV/Grid simulated).
    /// Demonstrates SRP and OCP: Only responsible for Excel formatting.
    /// </summary>
    public class ExcelReportFormatter : IReportFormatter
    {
        public string Format(Report report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report));
            }

            return $"=== [EXCEL FORMAT] ===\n" +
                   $"\"Report Title\",\"Summary\"\n" +
                   $"\"{report.Title}\",\"{report.GetSummary()}\"\n" +
                   $"======================";
        }
    }
}
