using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
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

        public IActionResult Index(string fase = "Grupo A", string filtro = "todos", string? grupo = null)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            int id = apostadorId.Value;

            // Jogos base
            var jogosQuery = _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .AsQueryable();

            // ===== FILTRO POR FASE =====
            if (!string.IsNullOrWhiteSpace(fase))
            {
                jogosQuery = jogosQuery.Where(j => j.Fase == fase);
            }

            // ===== PEGAR APOSTAS DO USUÁRIO =====
            var apostas = _context.Apostas
                .Where(a => a.ApostadorId == id)
                .ToList();

            var apostaJogoIds = apostas
                .Select(a => a.JogoId)
                .ToList();

            switch ((filtro ?? "todos").ToLower())
            {
                case "com":
                    jogosQuery = jogosQuery.Where(j => apostaJogoIds.Contains(j.Id));
                    break;

                case "sem":
                    jogosQuery = jogosQuery.Where(j => !apostaJogoIds.Contains(j.Id));
                    break;
            }

            var jogos = jogosQuery
                .OrderBy(j => j.DataHora)
                .ToList();

            ViewBag.Apostas = apostas;
            ViewBag.Filtro = filtro;
            ViewBag.Grupo = grupo ?? "";
            ViewBag.Fase = fase;

            return View(jogos);
        }

        [HttpPost]
        public IActionResult Salvar(
            int jogoId,
            int golsSelecaoA,
            int golsSelecaoB,
            string filtro = "todos",
            string? grupo = null)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            int id = apostadorId.Value;

            var jogo = _context.Jogos.FirstOrDefault(j => j.Id == jogoId);

            if (jogo == null || !jogo.EstaAberto)
                return RedirectToAction(nameof(Index), new { filtro, grupo });

            var aposta = _context.Apostas
                .FirstOrDefault(a => a.JogoId == jogoId && a.ApostadorId == id);

            var payload = ApostaHashService.GerarPayload(jogoId, id, golsSelecaoA, golsSelecaoB);

            if (aposta == null)
            {
                var salt = ApostaHashService.GerarSalt();
                var hash = ApostaHashService.GerarHash(payload, salt);

                aposta = new Aposta
                {
                    JogoId = jogoId,
                    ApostadorId = id,
                    SelecaoAId = jogo.SelecaoAId!.Value,
                    SelecaoBId = jogo.SelecaoBId!.Value,
                    GolsSelecaoA = golsSelecaoA,
                    GolsSelecaoB = golsSelecaoB,

                    Salt = salt,
                    HashCommit = hash,

                    CriadoEmUtc = DateTime.UtcNow,
                    AtualizadoEmUtc = DateTime.UtcNow
                };

                _context.Apostas.Add(aposta);
            }
            else
            {
                aposta.GolsSelecaoA = golsSelecaoA;
                aposta.GolsSelecaoB = golsSelecaoB;

                aposta.HashCommit = ApostaHashService.GerarHash(payload, aposta.Salt);

                aposta.AtualizadoEmUtc = DateTime.UtcNow;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { filtro, grupo });
        }
    }
}