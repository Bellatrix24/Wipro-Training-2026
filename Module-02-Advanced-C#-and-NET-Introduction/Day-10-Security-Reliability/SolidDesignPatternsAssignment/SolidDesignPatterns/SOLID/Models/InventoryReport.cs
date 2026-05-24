using System;

namespace SolidDesignPatterns.SOLID.Models
{
    /// <summary>
    /// Represents an inventory status report.
    /// Derived report safely substituting Report under LSP.
    /// </summary>
    public class InventoryReport : Report
    {
        public int TotalItems { get; set; }

        public InventoryReport(string title, string content, int totalItems)
            : base(title, content)
        {
            TotalItems = totalItems;
        }

        public override string GetSummary()
        {
            return $"Inventory Report Summary: Total items tracked in warehouse is {TotalItems}. Status: {Content}";
        }
    }
}
