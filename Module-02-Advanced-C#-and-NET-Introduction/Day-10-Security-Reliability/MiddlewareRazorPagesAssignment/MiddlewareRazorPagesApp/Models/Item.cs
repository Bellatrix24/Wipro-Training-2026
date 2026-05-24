using System;

namespace MiddlewareRazorPagesApp.Models
{
    /// <summary>
    /// Represents a catalog item in the library system.
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }
}
