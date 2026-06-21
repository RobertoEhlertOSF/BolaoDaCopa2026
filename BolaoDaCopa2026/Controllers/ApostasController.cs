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
        private readonly ApostaPrazoService _apostaPrazoService;
        private readonly JogoService _jogoService;

        public ApostasController(BolaoContext context, ApostaPrazoService apostaPrazoService, JogoService jogoService)
        {
            _context = context;
            _apostaPrazoService = apostaPrazoService;
            _jogoService = jogoService;
        }

        public IActionResult Index(string fase = "Grupo A", string filtro = "todos", string? grupo = null)
        {
            _jogoService.AtualizarJogosAgendadosParaEmAndamento();

            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            int id = apostadorId.Value;

            var jogosQuery = _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(fase))
            {
                jogosQuery = jogosQuery.Where(j => j.Fase == fase);
            }

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

            var agora = _apostaPrazoService.ObterAgora();

            var podeApostarPorJogo = jogos.ToDictionary(
                j => j.Id,
                j => _apostaPrazoService.PodeApostar(j, agora));

            var statusPorJogo = jogos.ToDictionary(
                j => j.Id,
                j => _apostaPrazoService.ObterStatusCronologico(j, agora));

            ViewBag.Apostas = apostas;
            ViewBag.PodeApostarPorJogo = podeApostarPorJogo;
            ViewBag.StatusPorJogo = statusPorJogo;
            ViewBag.Filtro = filtro;
            ViewBag.Grupo = grupo ?? "";
            ViewBag.Fase = fase;

            return View(jogos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Salvar(
            int jogoId,
            int golsSelecaoA,
            int golsSelecaoB,
            int? selecaoVencedoraId,
            string fase = "Grupo A",
            string filtro = "todos",
            string? grupo = null)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            if (golsSelecaoA < 0 || golsSelecaoB < 0)
                return BadRequest();

            int id = apostadorId.Value;

            var jogo = _context.Jogos.FirstOrDefault(j => j.Id == jogoId);

            if (jogo == null)
            {
                TempData["Erro"] = "Jogo não encontrado.";
                return RedirectToAction(nameof(Index), new { fase, filtro, grupo });
            }

            if (!_apostaPrazoService.PodeApostar(jogo))
            {
                TempData["Erro"] = "As apostas para este jogo já foram encerradas.";
                return RedirectToAction(nameof(Index), new { fase, filtro, grupo });
            }

            if (!TentarValidarSelecaoVencedora(
                    jogo,
                    golsSelecaoA,
                    golsSelecaoB,
                    selecaoVencedoraId,
                    out var selecaoVencedoraFinal,
                    out var erro))
            {
                TempData["Erro"] = erro;
                return RedirectToAction(nameof(Index), new { fase, filtro, grupo });
            }

            var aposta = _context.Apostas
                .FirstOrDefault(a => a.JogoId == jogoId && a.ApostadorId == id);

            UpsertAposta(jogo, id, golsSelecaoA, golsSelecaoB, selecaoVencedoraFinal, aposta);

            _context.SaveChanges();
            TempData["Sucesso"] = "Palpite salvo com sucesso.";

            return RedirectToAction(nameof(Index), new { fase, filtro, grupo });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalvarTodos(
            List<SalvarTodosApostaInput> apostas,
            string fase = "Grupo A",
            string filtro = "todos",
            string? grupo = null)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            if (apostas == null || apostas.Count == 0)
                return RedirectToAction(nameof(Index), new { fase, filtro, grupo });

            int id = apostadorId.Value;

            var apostasValidas = apostas
                .Where(a => a.GolsSelecaoA.HasValue && a.GolsSelecaoB.HasValue)
                .GroupBy(a => a.JogoId)
                .Select(g => g.Last())
                .ToList();

            if (apostasValidas.Count == 0)
                return RedirectToAction(nameof(Index), new { fase, filtro, grupo });

            var jogoIds = apostasValidas
                .Select(a => a.JogoId)
                .Distinct()
                .ToList();

            var jogos = _context.Jogos
                .Where(j => jogoIds.Contains(j.Id))
                .ToDictionary(j => j.Id);

            var apostasExistentes = _context.Apostas
                .Where(a => a.ApostadorId == id && jogoIds.Contains(a.JogoId))
                .ToDictionary(a => a.JogoId);

            var agora = _apostaPrazoService.ObterAgora();
            var totalSalvas = 0;
            var totalEncerradas = 0;
            var totalInvalidas = 0;

            foreach (var entrada in apostasValidas)
            {
                if (!jogos.TryGetValue(entrada.JogoId, out var jogo))
                    continue;

                var golsSelecaoAEntrada = entrada.GolsSelecaoA!.Value;
                var golsSelecaoBEntrada = entrada.GolsSelecaoB!.Value;

                if (golsSelecaoAEntrada < 0 || golsSelecaoBEntrada < 0)
                {
                    totalInvalidas++;
                    continue;
                }

                if (!_apostaPrazoService.PodeApostar(jogo, agora))
                {
                    totalEncerradas++;
                    continue;
                }

                if (!TentarValidarSelecaoVencedora(
                        jogo,
                        golsSelecaoAEntrada,
                        golsSelecaoBEntrada,
                        entrada.SelecaoVencedoraId,
                        out var selecaoVencedoraFinal,
                        out _))
                {
                    totalInvalidas++;
                    continue;
                }

                apostasExistentes.TryGetValue(entrada.JogoId, out var apostaExistente);

                UpsertAposta(
                    jogo,
                    id,
                    golsSelecaoAEntrada,
                    golsSelecaoBEntrada,
                    selecaoVencedoraFinal,
                    apostaExistente);

                totalSalvas++;
            }

            if (totalSalvas > 0)
                _context.SaveChanges();

            if (totalSalvas > 0)
                TempData["Sucesso"] = "Apostas salvas com sucesso.";

            if (totalEncerradas > 0 && totalInvalidas > 0)
                TempData["Erro"] = $"Algumas apostas não foram salvas: {totalEncerradas} jogo(s) já iniciado(s) e {totalInvalidas} palpite(s) inválido(s).";
            else if (totalEncerradas > 0)
                TempData["Erro"] = $"As apostas para {totalEncerradas} jogo(s) já foram encerradas.";
            else if (totalInvalidas > 0)
                TempData["Erro"] = $"Foram ignorados {totalInvalidas} palpite(s) inválido(s).";

            return RedirectToAction(nameof(Index), new { fase, filtro, grupo });
        }

        private void UpsertAposta(
            Jogo jogo,
            int apostadorId,
            int golsSelecaoA,
            int golsSelecaoB,
            int? selecaoVencedoraId,
            Aposta? aposta = null)
        {
            var payload = ApostaHashService.GerarPayload(jogo.Id, apostadorId, golsSelecaoA, golsSelecaoB);

            if (aposta == null)
            {
                var salt = ApostaHashService.GerarSalt();
                var hash = ApostaHashService.GerarHash(payload, salt);

                aposta = new Aposta
                {
                    JogoId = jogo.Id,
                    ApostadorId = apostadorId,
                    SelecaoAId = jogo.SelecaoAId!.Value,
                    SelecaoBId = jogo.SelecaoBId!.Value,
                    GolsSelecaoA = golsSelecaoA,
                    GolsSelecaoB = golsSelecaoB,
                    SelecaoVencedoraId = selecaoVencedoraId,

                    Salt = salt,
                    HashCommit = hash,

                    CriadoEmUtc = DateTime.UtcNow,
                    AtualizadoEmUtc = DateTime.UtcNow
                };

                _context.Apostas.Add(aposta);
                return;
            }

            aposta.GolsSelecaoA = golsSelecaoA;
            aposta.GolsSelecaoB = golsSelecaoB;
            aposta.SelecaoVencedoraId = selecaoVencedoraId;
            aposta.HashCommit = ApostaHashService.GerarHash(payload, aposta.Salt);
            aposta.AtualizadoEmUtc = DateTime.UtcNow;
        }

        private static bool EhFaseMataMata(string? fase)
        {
            return !string.IsNullOrWhiteSpace(fase)
                && !fase.StartsWith("Grupo ", StringComparison.OrdinalIgnoreCase);
        }

        private static bool TentarValidarSelecaoVencedora(
            Jogo jogo,
            int golsSelecaoA,
            int golsSelecaoB,
            int? selecaoVencedoraId,
            out int? selecaoVencedoraFinal,
            out string erro)
        {
            selecaoVencedoraFinal = null;
            erro = string.Empty;

            if (!EhFaseMataMata(jogo.Fase))
                return true;

            if (golsSelecaoA != golsSelecaoB)
                return true;

            if (!selecaoVencedoraId.HasValue)
            {
                erro = "Em jogos de mata-mata com palpite empatado, escolha quem avança.";
                return false;
            }

            if (selecaoVencedoraId.Value != jogo.SelecaoAId &&
                selecaoVencedoraId.Value != jogo.SelecaoBId)
            {
                erro = "Seleção vencedora inválida para este jogo.";
                return false;
            }

            selecaoVencedoraFinal = selecaoVencedoraId.Value;
            return true;
        }

        public class SalvarTodosApostaInput
        {
            public int JogoId { get; set; }
            public int? GolsSelecaoA { get; set; }
            public int? GolsSelecaoB { get; set; }
            public int? SelecaoVencedoraId { get; set; }
        }

        public IActionResult Campeao()
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            var apostador = _context.Apostadores
                .Include(a => a.SelecaoCampea)
                .FirstOrDefault(a => a.Id == apostadorId.Value);

            if (apostador == null)
                return Unauthorized();

            var selecoes = _context.Selecoes
                .OrderBy(s => s.Nome)
                .ToList();

            var primeiroJogo = _context.Jogos
                .OrderBy(j => j.DataHora)
                .FirstOrDefault();

            if (primeiroJogo == null)
                return NotFound();

            var prazoEncerrado = !_apostaPrazoService.PodeApostar(primeiroJogo);

            ViewBag.Apostador = apostador;
            ViewBag.PrazoEncerrado = prazoEncerrado;

            return View(selecoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalvarCampeao(int selecaoId)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
                return RedirectToAction("Login", "Conta");

            var apostador = _context.Apostadores
                .FirstOrDefault(a => a.Id == apostadorId.Value);

            if (apostador == null)
                return Unauthorized();

            var primeiroJogo = _context.Jogos
                .OrderBy(j => j.DataHora)
                .FirstOrDefault();

            if (primeiroJogo == null)
                return NotFound();

            if (!_apostaPrazoService.PodeApostar(primeiroJogo))
            {
                TempData["Erro"] = "O prazo para escolher o campeão já terminou.";
                return RedirectToAction("Campeao");
            }

            apostador.SelecaoCampeaId = selecaoId;

            _context.SaveChanges();

            TempData["Sucesso"] = "Campeão salvo com sucesso! 🏆";

            return RedirectToAction("Campeao");
        }
    }
}
