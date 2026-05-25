using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureTaskManagementPlatform.Data;
using SecureTaskManagementPlatform.Models;

namespace SecureTaskManagementPlatform.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> TaskList()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var tasks = await _context.Tasks
                .Where(t => t.UserId == user.Id)
                .OrderBy(t => t.IsCompleted)
                .ThenBy(t => t.DueDate)
                .AsNoTracking()
                .ToListAsync();

            ViewBag.UserFullName = user.FullName;
            return View(tasks);
        }
    }
}
