using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiddlewareRazorPagesApp.Models;

namespace MiddlewareRazorPagesApp.Pages.Items
{
    // Natural comment: Page model to display the list of items from our in-memory store.
    public class IndexModel : PageModel
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public void OnGet()
        {
            // Populate list from the static ItemStore
            Items = ItemStore.Items;
        }
    }
}
