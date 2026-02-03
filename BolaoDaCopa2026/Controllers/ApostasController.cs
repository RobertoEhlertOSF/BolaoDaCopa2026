using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Controllers
{
    public class ApostasController : Controller
    {
        private readonly BolaoContext _context;

        public ApostasController(BolaoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");
            if (apostadorId == null)
            {
                // não logado, redireciona ou trata o caso
                return RedirectToAction("Login", "Conta");
            }

            var jogos = _context.Jogos
                .Select(j => new Jogo
                {
                    Id = j.Id,
                    DataHora = j.DataHora,
                    Fase = j.Fase,
                    EstaAberto = j.EstaAberto,
                    SelecaoA = j.SelecaoA,
                    SelecaoB = j.SelecaoB
                })
                .ToList();


            var apostas = _context.Apostas
                .Where(a => a.ApostadorId == apostadorId)
                .ToList();

            ViewBag.Apostas = apostas;

            return View(jogos);
        }

        [HttpPost]
        public IActionResult Salvar(int jogoId, int golsSelecaoA, int golsSelecaoB, int? selecaoVencedoraId)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");
            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            var aposta = _context.Apostas
                .FirstOrDefault(a => a.JogoId == jogoId && a.ApostadorId == apostadorId);

            var jogo = _context.Jogos.FirstOrDefault(j => j.Id == jogoId);

            if (jogo == null || !jogo.EstaAberto)
                return RedirectToAction(nameof(Index));

            if (jogo.IsMataMata())
            {
                if (!selecaoVencedoraId.HasValue ||
                    (selecaoVencedoraId != jogo.SelecaoAId && selecaoVencedoraId != jogo.SelecaoBId))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            if (aposta == null)
            {
                aposta = new Aposta
                {
                    JogoId = jogoId,
                    ApostadorId = apostadorId.Value,
                    SelecaoAId = jogo.SelecaoAId,
                    SelecaoBId = jogo.SelecaoBId,
                    GolsSelecaoA = golsSelecaoA,
                    GolsSelecaoB = golsSelecaoB,
                    SelecaoVencedoraId = jogo.IsMataMata() ? selecaoVencedoraId : null
                };
                _context.Apostas.Add(aposta);
            }
            else
            {
                aposta.GolsSelecaoA = golsSelecaoA;
                aposta.GolsSelecaoB = golsSelecaoB;
                aposta.SelecaoVencedoraId = jogo.IsMataMata() ? selecaoVencedoraId : null;
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
