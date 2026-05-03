using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Controllers
{
    public class RankingController : Controller
    {
        private readonly BolaoContext _context;

        public RankingController(BolaoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Exigir login
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");
            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            // Ranking deve ser baseado em Apostadores, não em Apostas.
            // Assim, todos os participantes aparecem, mesmo que ainda não tenham apostas pontuadas.
            var ranking = _context.Apostadores
                .AsNoTracking()
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    PontosJogos = a.PontosJogos,
                    PontosCampeao = a.PontosCampeao,
                    PontosTotais = a.PontosJogos + a.PontosCampeao,
                    PlacaresExatos = a.PalpitesExatos
                })
                .OrderByDescending(a => a.PontosTotais)
                .ThenByDescending(a => a.PlacaresExatos)
                .ThenBy(a => a.Nome)
                .ToList();

            var pontosDoPrimeiro = ranking.FirstOrDefault()?.PontosTotais ?? 0;

            var linhas = new List<RankingLinhaViewModel>();

            for (int i = 0; i < ranking.Count; i++)
            {
                var item = ranking[i];

                linhas.Add(new RankingLinhaViewModel
                {
                    Posicao = i + 1,
                    Nome = item.Nome,
                    Pontos = item.PontosTotais,
                    DistanciaDoPrimeiro = Math.Max(0, pontosDoPrimeiro - item.PontosTotais),
                    PlacaresExatos = item.PlacaresExatos
                });
            }

            var vm = new RankingIndexViewModel
            {
                AtualizadoEmUtc = DateTime.UtcNow,
                TotalPremioTexto = "Em definição",
                Linhas = linhas
            };

            return View(vm);
        }
    }
}