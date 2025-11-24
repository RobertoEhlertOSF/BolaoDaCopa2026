using Microsoft.AspNetCore.Mvc;

namespace BolaoDaCopa2026.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
