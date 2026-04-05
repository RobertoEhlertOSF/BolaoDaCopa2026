using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Admin/Jogos")]
public class AdminJogosController : Controller
{
    private readonly BolaoContext _context;
    private readonly JogoService _jogoService;
    private readonly SelecaoService _selecaoService;
    private readonly ApostaService _apostaService;

    public AdminJogosController(
        BolaoContext context,
        JogoService jogoService,
        SelecaoService selecaoService,
        ApostaService apostaService)
    {
        _context = context;
        _jogoService = jogoService;
        _selecaoService = selecaoService;
        _apostaService = apostaService;
    }

    // =====================================================
    // MÉTODO PRIVADO - VALIDA ADMIN
    // =====================================================
    private bool UsuarioEhAdmin()
    {
        var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
        var usuario = _context.Usuarios.Find(usuarioId);

        return usuario != null && usuario.IsAdmin;
    }

    // =====================================================
    // TELA SEGUNDA FASE
    // =====================================================
    [HttpGet("SegundaFase")]
    public IActionResult SegundaFase()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Segunda Fase")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB 
            };

            vm.TodasSelecoes = selecoes.ToList();            

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    // =====================================================
    // TELA Oitavas
    // =====================================================
    [HttpGet("Oitavas")]
    public IActionResult Oitavas()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Oitavas")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora 
            };

            vm.TodasSelecoes = selecoes.ToList();

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    // =====================================================
    // TELA Quartas
    // =====================================================
    [HttpGet("Quartas")]
    public IActionResult Quartas()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Quartas")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora
            };

            vm.TodasSelecoes = selecoes.ToList();

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    // =====================================================
    // TELA Semifinal
    // =====================================================
    [HttpGet("Semifinal")]
    public IActionResult Semifinal()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Semifinal")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora
            };

            vm.TodasSelecoes = selecoes.ToList();

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    // =====================================================
    // TELA Terceiro Lugar
    // =====================================================
    [HttpGet("TerceiroLugar")]
    public IActionResult TerceiroLugar()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Terceiro Lugar")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora
            };

            vm.TodasSelecoes = selecoes.ToList();

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    // =====================================================
    // TELA Final
    // =====================================================
    [HttpGet("Final")]
    public IActionResult Final()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Where(j => j.Fase == "Final")
            .OrderBy(j => j.Id)
            .ToList();

        var selecoes = _context.Selecoes.ToList();

        var viewModel = new List<JogoAdminVM>();

        for (int i = 0; i < jogos.Count; i++)
        {
            var jogo = jogos[i];

            var vm = new JogoAdminVM
            {
                Id = jogo.Id,
                SelecaoAId = jogo.SelecaoAId,
                SelecaoBId = jogo.SelecaoBId,
                DescricaoSelecaoA = jogo.DescricaoSelecaoA,
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora
            };

            vm.TodasSelecoes = selecoes.ToList();

            viewModel.Add(vm);
        }

        return View(viewModel);
    }

    [HttpGet("DefinirCampeao")]
    public IActionResult DefinirCampeao()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var selecoes = _context.Selecoes.ToList();

        return View(selecoes);
    }

    [HttpPost("SalvarCampeao")]
    public IActionResult SalvarCampeao(int selecaoId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        // chama seu service centralizado
        _apostaService.RecalcularCampeao(selecaoId);

        return RedirectToAction("Index");
    }

    // =====================================================
    // SALVAR SEGUNDA FASE
    // =====================================================
    [HttpPost("SalvarSegundaFase")]
    public async Task<IActionResult> SalvarSegundaFase(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("SegundaFase");
    }

    // =====================================================
    // SALVAR Oitavas
    // =====================================================
    [HttpPost("SalvarOitavas")]
    public async Task<IActionResult> SalvarOitavas(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Oitavas");
    }

    // =====================================================
    // SALVAR Quartas
    // =====================================================
    [HttpPost("SalvarQuartas")]
    public async Task<IActionResult> SalvarQuartas(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Quartas");
    }

    // =====================================================
    // SALVAR Semifinal
    // =====================================================
    [HttpPost("SalvarSemifinal")]
    public async Task<IActionResult> SalvarSemifinal(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Semifinal");
    }

    // =====================================================
    // SALVAR Terceiro Lugar
    // =====================================================
    [HttpPost("SalvarTerceiroLugar")]
    public async Task<IActionResult> SalvarTerceiroLugar(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("TerceiroLugar");
    }

    // =====================================================
    // SALVAR Final
    // =====================================================
    [HttpPost("SalvarFinal")]
    public async Task<IActionResult> SalvarFinal(int id, int? selecaoAId, int? selecaoBId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.SelecaoAId = selecaoAId;
        jogo.SelecaoBId = selecaoBId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Final");
    }

    // =====================================================
    // LISTAR TODOS OS JOGOS
    // =====================================================
    [HttpGet("")]
    public IActionResult Index()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogos = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .OrderBy(j => j.DataHora)
            .ToList();

        return View(jogos);
    }

    // =====================================================
    // EDITAR JOGO
    // =====================================================
    [HttpGet("Editar/{id}")]
    public IActionResult Editar(int id)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .FirstOrDefault(j => j.Id == id);

        if (jogo == null)
            return NotFound();

        return View(jogo);
    }

    // =====================================================
    // FINALIZAR JOGO
    // =====================================================
    [HttpPost("Finalizar/{id}")]
    public IActionResult Finalizar(int id, int golsA, int golsB)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = _jogoService.FinalizarJogo(id, golsA, golsB);

        _selecaoService.AtualizarClassificacao(jogo);
        _apostaService.RecalcularApostasPorJogo(jogo);

        return RedirectToAction("Index");
    }
}
