using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Services;
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

            var pontuacaoService = new PontuacaoService();

            // Carrega apostas + jogos "fechados" (finalizados)
            var apostas = _context.Apostas
                .AsNoTracking()
                .Include(a => a.Apostador)
                .Include(a => a.Jogo)
                .Where(a => a.Jogo != null && a.Jogo.EstaAberto == false)
                .ToList();

            // Soma por apostador: Pontos + Placares Exatos
            var somaPorApostador = apostas
                .GroupBy(a => new { a.ApostadorId, Nome = a.Apostador.Nome })
                .Select(g => new
                {
                    g.Key.ApostadorId,
                    g.Key.Nome,

                    Pontos = g.Sum(a =>
                        pontuacaoService.CalcularPontuacaoApostador(
                            a.Jogo.GolsSelecaoA ?? 0,
                            a.Jogo.GolsSelecaoB ?? 0,
                            a.GolsSelecaoA,
                            a.GolsSelecaoB
                        )
                    ),

                    PlacaresExatos = g.Count(a =>
                        (a.Jogo.GolsSelecaoA ?? 0) == a.GolsSelecaoA &&
                        (a.Jogo.GolsSelecaoB ?? 0) == a.GolsSelecaoB
                    )
                })
                .OrderByDescending(x => x.Pontos)
                .ThenByDescending(x => x.PlacaresExatos) // desempate legal (opcional)
                .ThenBy(x => x.Nome)
                .ToList();

            var pontosDoPrimeiro = somaPorApostador.FirstOrDefault()?.Pontos ?? 0;

            // Monta linhas
            var linhas = new List<RankingLinhaViewModel>();
            for (int i = 0; i < somaPorApostador.Count; i++)
            {
                var item = somaPorApostador[i];

                linhas.Add(new RankingLinhaViewModel
                {
                    Posicao = i + 1,
                    Nome = item.Nome,
                    Pontos = item.Pontos,
                    DistanciaDoPrimeiro = Math.Max(0, pontosDoPrimeiro - item.Pontos),
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
