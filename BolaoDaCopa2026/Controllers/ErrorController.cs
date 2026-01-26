using BolaoDaCopa2026.View;
using Microsoft.AspNetCore.Mvc;

namespace BolaoDaCopa2026.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            var requestId = HttpContext.TraceIdentifier;
            return View("Error", requestId);
        }


    }
}
