using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Hello world");

            var car = new Car
            {
                Name = "Chevrolet",
                Model = "Corvette",
                Year = 2023
            };

            return View(car);
        }
    }
}
