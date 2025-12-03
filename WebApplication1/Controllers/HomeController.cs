using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            Student student = new Student();
            student.Id = 1;
            student.Name = "John Doe";
            student.Age = 20;
            TempData["StudentName"] = student.Name;
            return View();
        }

    }
}
