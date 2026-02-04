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

        // GET /Apostas?filtro=todos&grupo=A
        public IActionResult Index(string filtro = "todos", string? grupo = null)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");
            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            int id = apostadorId.Value;

            // IDs dos jogos em que o usuário já apostou
            var apostaJogoIdsQuery = _context.Apostas
                .AsNoTracking()
                .Where(a => a.ApostadorId == id)
                .Select(a => a.JogoId);

            // Base da lista de jogos
            var jogosQuery = _context.Jogos
                .AsNoTracking()
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .AsQueryable();

            // ===== FILTRO POR GRUPO =====
            // Assumindo que j.Fase vem como "Grupo A", "Grupo B", etc.
            if (!string.IsNullOrWhiteSpace(grupo))
            {
                var textoGrupo = $"Grupo {grupo.Trim().ToUpper()}";
                jogosQuery = jogosQuery.Where(j => j.Fase != null && j.Fase.Contains(textoGrupo));
            }

            // ===== FILTRO POR PALPITE =====
            // todos | com | sem
            switch ((filtro ?? "todos").ToLower())
            {
                case "com":
                    jogosQuery = jogosQuery.Where(j => apostaJogoIdsQuery.Contains(j.Id));
                    break;

                case "sem":
                    jogosQuery = jogosQuery.Where(j => !apostaJogoIdsQuery.Contains(j.Id));
                    break;

                case "todos":
                default:
                    break;
            }

            // ===== ORDEM FIXA (SEM "ORDENAR" NA UI) =====
            jogosQuery = jogosQuery.OrderBy(j => j.DataHora);

            // Carrega apostas do usuário pra view preencher os inputs
            var apostas = _context.Apostas
                .AsNoTracking()
                .Where(a => a.ApostadorId == id)
                .ToList();

            ViewBag.Apostas = apostas;

            // Guarda estado atual pra View manter selecionado
            ViewBag.Filtro = filtro;
            ViewBag.Grupo = grupo ?? "";

            var jogos = jogosQuery.ToList();
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

            if (aposta == null)
            {
                aposta = new Aposta
                {
                    JogoId = jogoId,
                    ApostadorId = id,
                    SelecaoAId = jogo.SelecaoAId,
                    SelecaoBId = jogo.SelecaoBId,
                    GolsSelecaoA = golsSelecaoA,
                    GolsSelecaoB = golsSelecaoB
                };
                _context.Apostas.Add(aposta);
            }
            else
            {
                aposta.GolsSelecaoA = golsSelecaoA;
                aposta.GolsSelecaoB = golsSelecaoB;
            }

            _context.SaveChanges();

            // volta mantendo filtros atuais
            return RedirectToAction(nameof(Index), new { filtro, grupo });
        }
    }
}
