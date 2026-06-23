using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Controllers
{
    public class SelecoesController : Controller
    {
        private readonly BolaoContext _context;

        public SelecoesController(BolaoContext context)
        {
            _context = context;
        }

        public IActionResult Index(string visao = "grupos")
        {
            const string textoNaoDefinido = "Não definido";

            var visaoNormalizada = string.Equals(visao, "mata-mata", StringComparison.OrdinalIgnoreCase)
                ? "mata-mata"
                : "grupos";

            var grupos = _context.Selecoes
                .AsNoTracking()
                .ToList()
                .GroupBy(s => s.Grupo)
                .OrderBy(g => g.Key)
                .Select(g => new GrupoClassificacaoViewModel
                {
                    NomeGrupo = g.Key,
                    Selecoes = g
                        .OrderByDescending(s => s.Pontos)
                        .ThenByDescending(s => s.GolsPro - s.GolsContra)
                        .ThenByDescending(s => s.GolsPro)
                        .ToList()
                })
                .ToList();

            var ordemFases = new List<(string Nome, string Rotulo)>
            {
                ("Segunda Fase", "2ª Fase"),
                ("Oitavas", "Oitavas"),
                ("Quartas", "Quartas"),
                ("Semifinal", "Semifinal"),
                ("Terceiro Lugar", "3º Lugar"),
                ("Final", "Final")
            };

            var nomesFases = ordemFases.Select(f => f.Nome).ToList();

            var jogosMataMata = _context.Jogos
                .AsNoTracking()
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .Where(j => nomesFases.Contains(j.Fase))
                .ToList();

            var fasesMataMata = ordemFases
                .Select(fase => new FaseMataMataViewModel
                {
                    NomeFase = fase.Nome,
                    Rotulo = fase.Rotulo,
                    Jogos = jogosMataMata
                        .Where(j => j.Fase == fase.Nome)
                        .OrderBy(j => j.DataHora)
                        .Select(j => new JogoMataMataViewModel
                        {
                            Id = j.Id,
                            NomeSelecaoA = j.SelecaoA?.Nome ?? j.DescricaoSelecaoA ?? textoNaoDefinido,
                            NomeSelecaoB = j.SelecaoB?.Nome ?? j.DescricaoSelecaoB ?? textoNaoDefinido,
                            BandeiraSelecaoA = j.SelecaoA?.BandeiraUrl,
                            BandeiraSelecaoB = j.SelecaoB?.BandeiraUrl,
                            OrigemSelecaoA = j.DescricaoSelecaoA,
                            OrigemSelecaoB = j.DescricaoSelecaoB,
                            DataHora = j.DataHora,
                            Status = string.IsNullOrWhiteSpace(j.Status) ? textoNaoDefinido : j.Status,
                            GolsSelecaoA = j.GolsSelecaoA,
                            GolsSelecaoB = j.GolsSelecaoB,
                            NomeVencedor = ObterNomeVencedor(j, textoNaoDefinido)
                        })
                        .ToList()
                })
                .ToList();

            var viewModel = new SelecoesIndexViewModel
            {
                VisaoAtual = visaoNormalizada,
                Grupos = grupos,
                FasesMataMata = fasesMataMata
            };

            return View("~/Views/Selecoes/Index.cshtml", viewModel);
        }

        private static string? ObterNomeVencedor(Jogo jogo, string textoNaoDefinido)
        {
            if (!jogo.SelecaoVencedoraId.HasValue)
                return null;

            if (jogo.SelecaoAId.HasValue && jogo.SelecaoVencedoraId.Value == jogo.SelecaoAId.Value)
                return jogo.SelecaoA?.Nome ?? textoNaoDefinido;

            if (jogo.SelecaoBId.HasValue && jogo.SelecaoVencedoraId.Value == jogo.SelecaoBId.Value)
                return jogo.SelecaoB?.Nome ?? textoNaoDefinido;

            return textoNaoDefinido;
        }

        public IActionResult GestaoSelecoes()
        {
            return View();
        }

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
