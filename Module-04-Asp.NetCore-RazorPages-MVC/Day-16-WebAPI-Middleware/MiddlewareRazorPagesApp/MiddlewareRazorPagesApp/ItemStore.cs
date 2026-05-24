using System.Collections.Generic;
using MiddlewareRazorPagesApp.Models;

namespace MiddlewareRazorPagesApp
{
    // Natural comment: Static in-memory database to store items dynamically.
    public static class ItemStore
    {
        public static List<Item> Items { get; set; } = new List<Item>
        {
            new Item 
            { 
                Name = "Project Guidelines", 
                Description = "All trainees must submit clean, well-commented code following git hygiene guidelines." 
            },
            new Item 
            { 
                Name = "Study Resources", 
                Description = "Refer to Module 04 notes on routing, pipeline middleware configurations, and layouts." 
            }
        };
    }
}
