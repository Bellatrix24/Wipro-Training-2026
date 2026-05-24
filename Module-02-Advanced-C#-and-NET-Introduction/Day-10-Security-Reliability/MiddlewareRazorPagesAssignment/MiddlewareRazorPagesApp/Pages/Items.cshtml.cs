using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiddlewareRazorPagesApp.Models;
using MiddlewareRazorPagesApp.Services;

namespace MiddlewareRazorPagesApp.Pages
{
    public class ItemsModel : PageModel
    {
        private readonly ItemStore _itemStore = new ItemStore();

        public IEnumerable<Item> CatalogItems { get; set; } = new List<Item>();

        public void OnGet()
        {
            // Retrieve all items from the shared static store
            CatalogItems = _itemStore.GetAll();
        }
    }
}
