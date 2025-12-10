using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

   public ProductController(AppDbContext context)
        {
 _context = context;
      }

   // GET: /Product/Details/5
public IActionResult Details(int id)
        {
   var product = _context.Products
     .Include(p => p.Category)
   .Include(p => p.ProductImages)
       .FirstOrDefault(p => p.Id == id && p.IsActive);

   if (product == null)
      {
             return NotFound();
  }

       // Increment view count
        product.ViewCount++;
            _context.SaveChanges();

    // Related products (same category)
     ViewBag.RelatedProducts = _context.Products
    .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id && p.IsActive)
      .OrderByDescending(p => p.ViewCount)
   .Take(4)
      .ToList();

            return View(product);
        }
    }
}
