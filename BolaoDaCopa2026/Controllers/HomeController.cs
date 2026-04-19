using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Models.ViewModels;
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
    var hoje = agora.Date;

    var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

    var jogosHoje = await _context.Jogos
        .Include(j => j.SelecaoA)
        .Include(j => j.SelecaoB)
        .Where(j => j.DataHora.Date == hoje)
        .OrderBy(j => j.DataHora)
        .Take(4)
        .ToListAsync();

    var jogos = jogosHoje;

    if (jogos.Count < 4)
    {
        var proximos = await _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .Where(j => j.DataHora > agora)
            .OrderBy(j => j.DataHora)
            .Take(4 - jogos.Count)
            .ToListAsync();

        jogos = jogos.Concat(proximos).ToList();
    }

    var apostasUsuario = new List<Aposta>();

    if (apostadorId != null)
    {
        var jogoIds = jogos.Select(j => j.Id).ToList();

        apostasUsuario = await _context.Apostas
            .Where(a => a.ApostadorId == apostadorId && jogoIds.Contains(a.JogoId))
            .ToListAsync();

        var apostador = await _context.Apostadores
            .Include(a => a.SelecaoCampea)
            .FirstOrDefaultAsync(a => a.Id == apostadorId);

        if (apostador != null && apostador.SelecaoCampeaId == null)
        {
            ViewBag.AvisoCampeao = true;
        }
        else
        {
            ViewBag.Campeao = apostador?.SelecaoCampea;
        }
    }

    var viewModel = new HomeViewModel
    {
        TemJogosHoje = jogosHoje.Any(),
        Jogos = jogos.Select(j => new JogoComApostaViewModel
        {
            Jogo = j,
            ApostaUsuario = apostasUsuario
                .FirstOrDefault(a => a.JogoId == j.Id)
        }).ToList()
    };

    return View(viewModel);
}

        [HttpGet]
        public async Task<IActionResult> ApostasJogo(int id)
        {
            var apostadorId = HttpContext.Session.GetInt32("ApostadorId");

            if (apostadorId == null)
            {
                return RedirectToAction("Login", "Conta");
            }

            var jogo = await _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }

            var apostaPorApostador = await _context.Apostas
                .Where(a => a.JogoId == id)
                .ToDictionaryAsync(a => a.ApostadorId);

            var apostadores = await _context.Apostadores
                .OrderBy(a => a.Nome)
                .ToListAsync();

            var viewModel = new ApostasDoJogoViewModel
            {
                Jogo = jogo,
                ApostasPorJogador = apostadores.Select(apostador =>
                {
                    apostaPorApostador.TryGetValue(apostador.Id, out var aposta);

                    return new ApostaJogadorItemViewModel
                    {
                        NomeUsuario = apostador.Nome,
                        GolsSelecaoA = aposta?.GolsSelecaoA,
                        GolsSelecaoB = aposta?.GolsSelecaoB
                    };
                }).ToList()
            };

            return View(viewModel);
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
