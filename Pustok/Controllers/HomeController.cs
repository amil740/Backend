using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Sliders
            var sliders = _context.Sliders
                .Where(s => s.IsActive)
                .OrderBy(s => s.Order)
                .ToList();

            // Featured Products
            ViewBag.FeaturedProducts = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsFeatured && p.IsActive)
                .OrderByDescending(p => p.ViewCount)
                .Take(12)
                .ToList();

            // New Arrivals
            ViewBag.NewArrivals = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsNew && p.IsActive)
                .OrderByDescending(p => p.CreatedDate)
                .Take(12)
                .ToList();

            // Most Viewed Products
            ViewBag.MostViewedProducts = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.ViewCount)
                .Take(12)
                .ToList();

            // Deal of the Day (On Sale Products)
            ViewBag.DealsOfDay = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsOnSale && p.IsActive && p.SaleEndDate.HasValue && p.SaleEndDate.Value > DateTime.Now)
                .OrderByDescending(p => p.DiscountPercentage)
                .Take(7)
                .ToList();

            // Best Sellers
            ViewBag.BestSellers = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.SalesCount)
                .Take(6)
                .ToList();

            // Children's Books
            var childrenCategory = _context.Categories.FirstOrDefault(c => c.Name == "Children's Books");
            if (childrenCategory != null)
            {
                ViewBag.ChildrensBooks = _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.CategoryId == childrenCategory.Id && p.IsActive)
                    .OrderByDescending(p => p.ViewCount)
                    .Take(6)
                    .ToList();
            }

            // Arts & Photography Books
            var artsCategory = _context.Categories.FirstOrDefault(c => c.Name == "Arts & Photography");
            if (artsCategory != null)
            {
                ViewBag.ArtsBooks = _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.CategoryId == artsCategory.Id && p.IsActive)
                    .OrderByDescending(p => p.ViewCount)
                    .Take(7)
                    .ToList();
            }

            return View(sliders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
