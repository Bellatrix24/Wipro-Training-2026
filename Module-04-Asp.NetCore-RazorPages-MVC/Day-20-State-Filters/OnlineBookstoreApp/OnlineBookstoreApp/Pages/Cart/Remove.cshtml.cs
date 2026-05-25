using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Extensions;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Pages.Cart
{
    public class RemoveModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(i => i.Book.Id == id);
            if (existingItem != null)
            {
                cart.Remove(existingItem);
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            TempData["Success"] = "Item removed from your shopping cart.";
            return RedirectToPage("/Cart/Index");
        }
    }
}
