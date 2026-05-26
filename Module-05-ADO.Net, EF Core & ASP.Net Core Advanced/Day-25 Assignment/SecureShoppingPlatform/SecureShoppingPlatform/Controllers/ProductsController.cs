using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureShoppingPlatform.Data;
using SecureShoppingPlatform.Models;
using SecureShoppingPlatform.ViewModels;

namespace SecureShoppingPlatform.Controllers
{
    [Authorize(Roles = "Customer,Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToListAsync();

            return View(products);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> Purchase(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new PurchaseViewModel { ProductId = id, Product = product });
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(PurchaseViewModel model)
        {
            var product = await _context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return NotFound();
            }

            if (model.Quantity > product.Stock)
            {
                ModelState.AddModelError(nameof(model.Quantity), "Not enough stock available.");
            }

            if (!ModelState.IsValid)
            {
                model.Product = product;
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var order = new Order
            {
                UserId = user.Id,
                ShippingAddress = model.ShippingAddress.Trim(),
                TotalAmount = product.Price * model.Quantity,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = product.ProductId,
                        Quantity = model.Quantity,
                        UnitPrice = product.Price
                    }
                }
            };

            product.Stock -= model.Quantity;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyOrders", "Orders");
        }
    }
}
