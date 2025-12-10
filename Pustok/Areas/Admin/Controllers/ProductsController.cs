using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                  .Include(p => p.Category)
                         .OrderByDescending(p => p.CreatedDate)
                  .ToListAsync();
            return View(products);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories
                        .Where(c => c.IsActive)
                           .ToListAsync();
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            // Additional server-side validations
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                ModelState.AddModelError("Name", "Product name is required");
            }

            if (product.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price must be greater than 0");
            }

            if (product.OldPrice.HasValue && product.OldPrice <= product.Price)
            {
                ModelState.AddModelError("OldPrice", "Old price must be greater than current price");
            }

            if (product.StockQuantity < 0)
            {
                ModelState.AddModelError("StockQuantity", "Stock quantity cannot be negative");
            }

            // Check if category exists
            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && c.IsActive))
            {
                ModelState.AddModelError("CategoryId", "Selected category is invalid or inactive");
            }

            // Check for duplicate SKU
            if (!string.IsNullOrWhiteSpace(product.SKU))
            {
                if (await _context.Products.AnyAsync(p => p.SKU == product.SKU))
                {
                    ModelState.AddModelError("SKU", "This SKU already exists");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.CreatedDate = DateTime.Now;
                    product.ViewCount = 0;
                    product.SalesCount = 0;
                    product.ReviewCount = 0;
                    product.Rating = 0;

                    _context.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Product created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving: " + ex.Message);
                }
            }

            ViewBag.Categories = await _context.Categories
     .Where(c => c.IsActive)
       .ToListAsync();
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _context.Categories
          .Where(c => c.IsActive)
    .ToListAsync();
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            // Additional server-side validations
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                ModelState.AddModelError("Name", "Product name is required");
            }

            if (product.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price must be greater than 0");
            }

            if (product.OldPrice.HasValue && product.OldPrice <= product.Price)
            {
                ModelState.AddModelError("OldPrice", "Old price must be greater than current price");
            }

            if (product.StockQuantity < 0)
            {
                ModelState.AddModelError("StockQuantity", "Stock quantity cannot be negative");
            }

            // Check if category exists
            if (!await _context.Categories.AnyAsync(c => c.Id == product.CategoryId && c.IsActive))
            {
                ModelState.AddModelError("CategoryId", "Selected category is invalid or inactive");
            }

            // Check for duplicate SKU (excluding current product)
            if (!string.IsNullOrWhiteSpace(product.SKU))
            {
                if (await _context.Products.AnyAsync(p => p.SKU == product.SKU && p.Id != id))
                {
                    ModelState.AddModelError("SKU", "This SKU already exists");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.Products.FindAsync(id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    // Update only allowed fields
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.OldPrice = product.OldPrice;
                    existingProduct.DiscountPercentage = product.DiscountPercentage;
                    existingProduct.Author = product.Author;
                    existingProduct.StockQuantity = product.StockQuantity;
                    existingProduct.SKU = product.SKU;
                    existingProduct.ISBN = product.ISBN;
                    existingProduct.PageCount = product.PageCount;
                    existingProduct.Publisher = product.Publisher;
                    existingProduct.PublishDate = product.PublishDate;
                    existingProduct.Language = product.Language;
                    existingProduct.Weight = product.Weight;
                    existingProduct.Dimensions = product.Dimensions;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.IsActive = product.IsActive;
                    existingProduct.IsFeatured = product.IsFeatured;
                    existingProduct.IsNew = product.IsNew;
                    existingProduct.IsOnSale = product.IsOnSale;
                    existingProduct.SaleEndDate = product.SaleEndDate;

                    _context.Update(existingProduct);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Product updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "The product was modified by another user. Please reload and try again.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving: " + ex.Message);
                }
            }

            ViewBag.Categories = await _context.Categories
     .Where(c => c.IsActive)
            .ToListAsync();
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Product deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Product not found!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting product: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
