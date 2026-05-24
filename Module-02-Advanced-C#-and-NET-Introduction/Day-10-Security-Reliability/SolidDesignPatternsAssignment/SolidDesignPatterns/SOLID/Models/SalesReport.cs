using System;

namespace SolidDesignPatterns.SOLID.Models
{
    /// <summary>
    /// Represents a sales transaction report.
    /// Derived report safely substituting Report under LSP.
    /// </summary>
    public class SalesReport : Report
    {
        public double TotalRevenue { get; set; }

        public SalesReport(string title, string content, double totalRevenue)
            : base(title, content)
        {
            TotalRevenue = totalRevenue;
        }

        public override string GetSummary()
        {
            return $"Sales Report Summary: Total Revenue generated is {TotalRevenue:C}. Details: {Content}";
        }
    }
}
