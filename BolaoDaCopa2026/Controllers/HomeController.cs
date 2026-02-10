using BolaoDaCopa2026.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BolaoDaCopa2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly BolaoContext _context;

        public IActionResult Regras()
        {
            return View();
        }


        public HomeController(BolaoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var agora = DateTime.Now;

            var proximosJogos = _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .Where(j => j.DataHora > agora)
                .OrderBy(j => j.DataHora)
                .Take(2)
                .ToList();

            return View(proximosJogos);
        }

        [Route("Home/Error")]
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View("Error");
        }

        [HttpGet]
        public IActionResult EditarResultado(int id)
        {
            if (!UsuarioEhAdmin())
                return Unauthorized();

            var jogo = _context.Jogos.Find(id);
            return View(jogo);
        }

        private bool UsuarioEhAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }


    }
}
