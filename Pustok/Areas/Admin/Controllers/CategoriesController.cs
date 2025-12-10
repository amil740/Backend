using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Include(c => c.ParentCategory)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
            return View(categories);
        }

        // GET: Admin/Categories/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ParentCategories = await _context.Categories
                .Where(c => c.ParentCategoryId == null && c.IsActive)
                .ToListAsync();
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            // Additional server-side validations
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Category name is required");
            }

            // Check for duplicate category name
            if (await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "A category with this name already exists");
            }

            // Validate parent category if selected
            if (category.ParentCategoryId.HasValue)
            {
                if (!await _context.Categories.AnyAsync(c => c.Id == category.ParentCategoryId && c.IsActive))
                {
                    ModelState.AddModelError("ParentCategoryId", "Selected parent category is invalid or inactive");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.CreatedDate = DateTime.Now;
                    _context.Add(category);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Category created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving: " + ex.Message);
                }
            }

            ViewBag.ParentCategories = await _context.Categories
                .Where(c => c.ParentCategoryId == null && c.IsActive)
                .ToListAsync();
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.ParentCategories = await _context.Categories
                .Where(c => c.ParentCategoryId == null && c.Id != id && c.IsActive)
                .ToListAsync();
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            // Additional server-side validations
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Category name is required");
            }

            // Check for duplicate category name (excluding current category)
            if (await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower() && c.Id != id))
            {
                ModelState.AddModelError("Name", "A category with this name already exists");
            }

            // Validate parent category if selected
            if (category.ParentCategoryId.HasValue)
            {
                if (category.ParentCategoryId == id)
                {
                    ModelState.AddModelError("ParentCategoryId", "A category cannot be its own parent");
                }
                else if (!await _context.Categories.AnyAsync(c => c.Id == category.ParentCategoryId && c.IsActive))
                {
                    ModelState.AddModelError("ParentCategoryId", "Selected parent category is invalid or inactive");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = await _context.Categories.FindAsync(id);
                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    // Update only allowed fields
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                    existingCategory.IconClass = category.IconClass;
                    existingCategory.ParentCategoryId = category.ParentCategoryId;
                    existingCategory.IsActive = category.IsActive;

                    _context.Update(existingCategory);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Category updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "The category was modified by another user. Please reload and try again.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving: " + ex.Message);
                }
            }

            ViewBag.ParentCategories = await _context.Categories
                .Where(c => c.ParentCategoryId == null && c.Id != id && c.IsActive)
                .ToListAsync();
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var category = await _context.Categories
                    .Include(c => c.SubCategories)
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (category != null)
                {
                    // Check if category has subcategories
                    if (category.SubCategories.Any())
                    {
                        TempData["ErrorMessage"] = "Cannot delete category with subcategories. Please delete subcategories first.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Check if category has products
                    if (category.Products.Any())
                    {
                        TempData["ErrorMessage"] = "Cannot delete category with products. Please reassign or delete products first.";
                        return RedirectToAction(nameof(Index));
                    }

                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Category deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Category not found!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting category: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
