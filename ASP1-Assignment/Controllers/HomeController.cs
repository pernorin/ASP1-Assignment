using Microsoft.AspNetCore.Mvc;

namespace ASP1_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
