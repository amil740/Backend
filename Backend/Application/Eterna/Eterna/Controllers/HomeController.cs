using System.Diagnostics;
using Eterna.Data;
using Eterna.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eterna.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sliders = _context.Sliders.ToList();
            var model = new HomeViewModel
            {
                Sliders = sliders
            };
            return View(model);
        }
    }
}
