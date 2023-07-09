using Microsoft.AspNetCore.Mvc;

namespace MVCCRUD.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
