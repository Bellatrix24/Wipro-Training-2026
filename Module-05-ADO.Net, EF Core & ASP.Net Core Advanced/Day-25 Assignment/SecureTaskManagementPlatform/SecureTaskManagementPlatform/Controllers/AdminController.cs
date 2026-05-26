using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureTaskManagementPlatform.Data;

namespace SecureTaskManagementPlatform.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ManageTasks()
        {
            var tasks = await _context.Tasks
                .Include(t => t.User)
                .OrderBy(t => t.IsCompleted)
                .ThenBy(t => t.DueDate)
                .AsNoTracking()
                .ToListAsync();

            return View(tasks);
        }
    }
}
