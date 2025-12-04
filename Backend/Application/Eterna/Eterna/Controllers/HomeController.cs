using System.Diagnostics;
using Eterna.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eterna.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
