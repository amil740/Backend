using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
