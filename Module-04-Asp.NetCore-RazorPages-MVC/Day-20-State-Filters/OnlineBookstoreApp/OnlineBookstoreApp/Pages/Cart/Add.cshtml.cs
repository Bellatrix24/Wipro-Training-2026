using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstoreApp.Extensions;
using OnlineBookstoreApp.Models;
using OnlineBookstoreApp.Repositories;

namespace OnlineBookstoreApp.Pages.Cart
{
    public class AddModel : PageModel
    {
        private readonly IBookRepository _bookRepository;

        public AddModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult OnGet(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} was not found.");
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(i => i.Book.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Book = book, Quantity = 1 });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            TempData["Success"] = $"Added '{book.Title}' to your shopping cart!";
            return RedirectToPage("/Cart/Index");
        }
    }
}
