using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = new[]
            {
                new { Id = 1, Name = "Electronics", Description = "Electronic items" },
                new { Id = 2, Name = "Books", Description = "Various kinds of books" },
                new { Id = 3, Name = "Clothing", Description = "Apparel and garments" }
            };

            return Ok(categories);
        }
    }
}
