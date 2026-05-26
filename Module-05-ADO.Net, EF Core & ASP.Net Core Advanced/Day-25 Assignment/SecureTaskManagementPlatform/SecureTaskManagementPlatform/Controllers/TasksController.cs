using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureTaskManagementPlatform.Data;
using SecureTaskManagementPlatform.Models;
using SecureTaskManagementPlatform.ViewModels;

namespace SecureTaskManagementPlatform.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TasksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.User)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(t => t.TaskId == id);

            if (task == null) return NotFound();

            // Simple security check: regular users can only see their own tasks
            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && task.UserId != user?.Id)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TaskViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            // Sanitize text inputs explicitly to prevent stored XSS and malicious characters
            var task = new TaskItem
            {
                Title = HtmlEncoder.Default.Encode(model.Title.Trim()),
                Description = HtmlEncoder.Default.Encode(model.Description.Trim()),
                DueDate = model.DueDate,
                IsCompleted = false,
                UserId = user.Id
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Policy = "CanEditTask")]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && task.UserId != user?.Id)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var model = new TaskViewModel
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                DueDate = task.DueDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CanEditTask")]
        public async Task<IActionResult> Edit(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var task = await _context.Tasks.FindAsync(model.TaskId);
            if (task == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && task.UserId != user?.Id)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            // Sanitize inputs
            task.Title = HtmlEncoder.Default.Encode(model.Title.Trim());
            task.Description = HtmlEncoder.Default.Encode(model.Description.Trim());
            task.IsCompleted = model.IsCompleted;
            task.DueDate = model.DueDate;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int taskId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return RedirectToAction("Details", new { id = taskId });
            }

            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var comment = new TaskComment
            {
                TaskId = taskId,
                UserId = user.Id,
                Content = HtmlEncoder.Default.Encode(content.Trim()),
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = taskId });
        }
    }
}
