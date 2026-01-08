using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace BolaoDaCopa2026.Controllers
{
    public class SelecoesController : Controller
    {
        private readonly BolaoContext _context;

        public SelecoesController(BolaoContext context)
        {
            _context = context;
        }

        // GET: /Selecoes
        public IActionResult Index()
        {
            var selecoes = _context.Selecoes.ToList();
            return View(selecoes);
        }

        // GET: /Selecoes/Create
        public IActionResult GestaoSelecoes()
        {
            return View();
        }

        // POST: /Selecoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Selecao selecao)
        {
            if (!ModelState.IsValid)
                return View(selecao);

            _context.Selecoes.Add(selecao);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
