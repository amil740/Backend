using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly AppDbContext _context;

        public SlidersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders
           .OrderBy(s => s.Order)
            .ToListAsync();
            return View(sliders);
        }

        [HttpGet]
        public async Task<IActionResult> GetSlider(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return Json(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Slider slider)
        {
            if (ModelState.IsValid)
            {
                slider.CreatedDate = DateTime.Now;
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Slider created successfully!" });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors = errors });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] Slider slider)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Slider updated successfully!" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.Id))
                    {
                        return Json(new { success = false, message = "Slider not found!" });
                    }
                    throw;
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, errors = errors });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return Json(new { success = false, message = "Slider not found!" });
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Slider deleted successfully!" });
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.Id == id);
        }
    }
}
