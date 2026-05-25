using Microsoft.AspNetCore.Mvc;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authors;

        public AuthorsController(IAuthorRepository authors)
        {
            _authors = authors;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authors.GetAuthorsWithBooksAsync();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreateEditPartial", new Author());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _authors.AddAsync(author);
                return Json(new { success = true, message = "Author added successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authors.GetByIdAsync(id);
            if (author == null) return NotFound();
            return PartialView("_CreateEditPartial", author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _authors.UpdateAsync(author);
                return Json(new { success = true, message = "Author updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _authors.DeleteAsync(id);
                return Json(new { success = true, message = "Author deleted." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
