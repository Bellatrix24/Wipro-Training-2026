using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureShoppingPlatform.Data;

namespace SecureShoppingPlatform.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.OrderCount = await _context.Orders.CountAsync();
            ViewBag.TotalSales = await _context.Orders.SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var recentOrders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate)
                .Take(10)
                .AsNoTracking()
                .ToListAsync();

            return View(recentOrders);
        }
    }
}
