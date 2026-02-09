using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services; // <<< NOVO
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
            if (!string.IsNullOrWhiteSpace(grupo))
            {
                var textoGrupo = $"Grupo {grupo.Trim().ToUpper()}";
                jogosQuery = jogosQuery.Where(j => j.Fase != null && j.Fase.Contains(textoGrupo));
            }

            // ===== FILTRO POR PALPITE =====
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

            // ===== ORDEM FIXA =====
            jogosQuery = jogosQuery.OrderBy(j => j.DataHora);

            // Carrega apostas do usuário
            var apostas = _context.Apostas
                .AsNoTracking()
                .Where(a => a.ApostadorId == id)
                .ToList();

            ViewBag.Apostas = apostas;

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

            // Se jogo não existe ou já fechou, não permite salvar/editar
            if (jogo == null || !jogo.EstaAberto)
                return RedirectToAction(nameof(Index), new { filtro, grupo });

            var aposta = _context.Apostas
                .FirstOrDefault(a => a.JogoId == jogoId && a.ApostadorId == id);

            // === NOVO: monta payload uma vez (com os gols atuais) ===
            var payload = ApostaHashService.GerarPayload(jogoId, id, golsSelecaoA, golsSelecaoB);

            if (aposta == null)
            {
                // === NOVO: gera salt e hash ao criar ===
                var salt = ApostaHashService.GerarSalt();
                var hash = ApostaHashService.GerarHash(payload, salt);

                aposta = new Aposta
                {
                    JogoId = jogoId,
                    ApostadorId = id,
                    SelecaoAId = jogo.SelecaoAId,
                    SelecaoBId = jogo.SelecaoBId,
                    GolsSelecaoA = golsSelecaoA,
                    GolsSelecaoB = golsSelecaoB,

                    // 🔐 novos campos
                    Salt = salt,
                    HashCommit = hash,

                    // 🕒 auditoria
                    CriadoEmUtc = DateTime.UtcNow,
                    AtualizadoEmUtc = DateTime.UtcNow
                };

                _context.Apostas.Add(aposta);
            }
            else
            {
                // Atualiza placar
                aposta.GolsSelecaoA = golsSelecaoA;
                aposta.GolsSelecaoB = golsSelecaoB;

                // === NOVO: recalcula hash usando o MESMO salt ===
                // Isso garante que qualquer alteração muda o HashCommit
                aposta.HashCommit = ApostaHashService.GerarHash(payload, aposta.Salt);

                // 🕒 auditoria
                aposta.AtualizadoEmUtc = DateTime.UtcNow;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { filtro, grupo });
        }
    }
}
