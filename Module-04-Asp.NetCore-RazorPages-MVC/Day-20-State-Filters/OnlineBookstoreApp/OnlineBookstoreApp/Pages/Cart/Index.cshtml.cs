using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Extensions;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalAmount { get; set; }

        public void OnGet()
        {
            CartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            
            TotalAmount = 0;
            foreach (var item in CartItems)
            {
                TotalAmount += item.Book.Price * item.Quantity;
            }
        }
    }
}
