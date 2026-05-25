using Microsoft.AspNetCore.Mvc;
using AdvancedLibraryManagementSystem.Interfaces;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genres;

        public GenresController(IGenreRepository genres)
        {
            _genres = genres;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genres.GetAllAsync();
            return View(genres);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreateEditPartial", new Genre());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _genres.AddAsync(genre);
                return Json(new { success = true, message = "Genre added successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genres.GetByIdAsync(id);
            if (genre == null) return NotFound();
            return PartialView("_CreateEditPartial", genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Validation failed." });

            try
            {
                await _genres.UpdateAsync(genre);
                return Json(new { success = true, message = "Genre updated successfully." });
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
                await _genres.DeleteAsync(id);
                return Json(new { success = true, message = "Genre deleted." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
