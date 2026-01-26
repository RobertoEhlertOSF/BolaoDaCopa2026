using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BolaoDaCopa2026.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

            [Route("Home/Error")]
            public IActionResult Error()
            {
                ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                return View("Error");
            }
    }    
}
