using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
using BolaoDaCopa2026.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

[Route("Admin/Jogos")]
public class AdminJogosController : Controller
{
    private readonly BolaoContext _context;
    private readonly JogoService _jogoService;
    private readonly SelecaoService _selecaoService;
    private readonly ApostaService _apostaService;
    private readonly IEmailService _emailService;

    public AdminJogosController(
        BolaoContext context,
        JogoService jogoService,
        SelecaoService selecaoService,
        ApostaService apostaService,
        IEmailService emailService)
    {
        _context = context;
        _jogoService = jogoService;
        _selecaoService = selecaoService;
        _apostaService = apostaService;
        _emailService = emailService;
    }

    // =====================================================
    // MÉTODO PRIVADO - VALIDA ADMIN
    // =====================================================
    private bool UsuarioEhAdmin()
    {
        var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

        if (usuarioId == null)
            return false;

        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.Id == usuarioId.Value);

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
                DescricaoSelecaoB = jogo.DescricaoSelecaoB,
                DataHora = jogo.DataHora
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
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

        _jogoService.AtualizarJogosAgendadosParaEmAndamento();

        var jogos = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .OrderBy(j => j.DataHora)
            .ToList();

        return View(jogos);
    }

    // =====================================================
    // GERENCIAR USUÁRIOS
    // =====================================================
    [HttpGet("Usuarios")]
    public IActionResult Usuarios()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var usuarios = _context.Usuarios
            .AsNoTracking()
            .Where(u => !u.IsAdmin)
            .Select(u => new AdminUsuarioVM
            {
                UsuarioId = u.Id,
                Nome = u.Apostador != null ? u.Apostador.Nome : "(Sem nome)",
                Email = u.Email,
                TotalApostas = u.Apostador != null ? u.Apostador.Apostas.Count : 0
            })
            .OrderBy(u => u.Nome)
            .ToList();

        return View(usuarios);
    }

    [HttpPost("Usuarios/AtualizarEmail")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AtualizarEmailUsuario(int usuarioId, string novoEmail)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        if (string.IsNullOrWhiteSpace(novoEmail))
        {
            TempData["Erro"] = "Informe um e-mail válido.";
            return RedirectToAction(nameof(Usuarios));
        }

        var emailNormalizado = novoEmail.Trim().ToLowerInvariant();
        if (!new EmailAddressAttribute().IsValid(emailNormalizado))
        {
            TempData["Erro"] = "Formato de e-mail inválido.";
            return RedirectToAction(nameof(Usuarios));
        }

        var emailJaEmUso = await _context.Usuarios
            .AnyAsync(u => u.Id != usuarioId && u.Email.ToLower() == emailNormalizado);

        if (emailJaEmUso)
        {
            TempData["Erro"] = "Este e-mail já está cadastrado para outro usuário.";
            return RedirectToAction(nameof(Usuarios));
        }

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id == usuarioId && !u.IsAdmin);

        if (usuario == null)
        {
            TempData["Erro"] = "Usuário não encontrado.";
            return RedirectToAction(nameof(Usuarios));
        }

        usuario.Email = emailNormalizado;
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "E-mail atualizado com sucesso.";
        return RedirectToAction(nameof(Usuarios));
    }

    [HttpPost("Usuarios/ResetarSenha")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetarSenhaUsuario(int usuarioId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id == usuarioId && !u.IsAdmin);

        if (usuario == null)
        {
            TempData["Erro"] = "Usuário não encontrado.";
            return RedirectToAction(nameof(Usuarios));
        }

        var tokensAntigos = await _context.PasswordResetTokens
            .Where(t =>
                t.UsuarioId == usuario.Id &&
                !t.Utilizado &&
                t.ExpiraEmUtc > DateTime.UtcNow)
            .ToListAsync();

        foreach (var tokenAntigo in tokensAntigos)
        {
            tokenAntigo.Utilizado = true;
            tokenAntigo.UtilizadoEmUtc = DateTime.UtcNow;
        }

        var token = GerarTokenSeguro();
        var tokenHash = GerarHashDoToken(token);

        var resetToken = new PasswordResetToken
        {
            UsuarioId = usuario.Id,
            TokenHash = tokenHash,
            CriadoEmUtc = DateTime.UtcNow,
            ExpiraEmUtc = DateTime.UtcNow.AddHours(1),
            Utilizado = false
        };

        _context.PasswordResetTokens.Add(resetToken);
        await _context.SaveChangesAsync();

        var link = Url.Action(
            action: "RedefinirSenha",
            controller: "Conta",
            values: new { token },
            protocol: Request.Scheme
        );

        if (string.IsNullOrWhiteSpace(link))
        {
            TempData["Erro"] = "Não foi possível gerar o link de redefinição.";
            return RedirectToAction(nameof(Usuarios));
        }

        var corpoEmail = $@"
        <h2>Redefinição de senha</h2>
        <p>Um administrador solicitou a redefinição da sua senha no Bolão da Copa Nappers 2026.</p>
        <p>
            <a href=""{link}"">Clique aqui para redefinir sua senha</a>
        </p>
        <p>Este link expira em 1 hora.</p>
        ";

        await _emailService.EnviarAsync(
            usuario.Email,
            "Redefinição de senha - Bolão da Copa Nappers 2026",
            corpoEmail
        );

        TempData["Sucesso"] = $"Link de redefinição enviado para {usuario.Email}.";
        return RedirectToAction(nameof(Usuarios));
    }

    private static string GerarTokenSeguro()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return WebEncoders.Base64UrlEncode(bytes);
    }

    private static string GerarHashDoToken(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }

    [HttpPost("Usuarios/Excluir")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExcluirUsuario(int usuarioId)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var usuarioLogadoId = HttpContext.Session.GetInt32("UsuarioId");
        if (usuarioLogadoId == usuarioId)
        {
            TempData["Erro"] = "Não é possível excluir o usuário atualmente logado.";
            return RedirectToAction(nameof(Usuarios));
        }

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id == usuarioId && !u.IsAdmin);

        if (usuario == null)
        {
            TempData["Erro"] = "Usuário não encontrado.";
            return RedirectToAction(nameof(Usuarios));
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Usuário excluído com sucesso.";
        return RedirectToAction(nameof(Usuarios));
    }

    [HttpPost("RecalcularPontuacoes")]
    [ValidateAntiForgeryToken]
    public IActionResult RecalcularPontuacoes()
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        using var transaction = _context.Database.BeginTransaction();

        try
        {
            _apostaService.RecalcularTudo();
            _context.SaveChanges();
            transaction.Commit();

            TempData["Sucesso"] = "Pontuações e placares exatos recalculados com sucesso.";
        }
        catch
        {
            transaction.Rollback();
            TempData["Erro"] = "Não foi possível recalcular as pontuações.";
        }

        return RedirectToAction(nameof(Index));
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

    [HttpPost("AtualizarDataHora/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AtualizarDataHora(int id, DateTime dataHora)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null)
            return NotFound();

        jogo.DataHora = dataHora;
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Dia e horario atualizados com sucesso.";
        return RedirectToAction(nameof(Editar), new { id });
    }

    // =====================================================
    // FINALIZAR JOGO
    // =====================================================
    [HttpPost("Finalizar/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult Finalizar(int id, int golsA, int golsB)
    {
        if (!UsuarioEhAdmin())
            return Forbid();

        if (golsA < 0 || golsB < 0)
            return BadRequest();

        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var jogo = _jogoService.FinalizarJogo(id, golsA, golsB);

            _selecaoService.AtualizarClassificacao(jogo);
            _apostaService.RecalcularApostasPorJogo(jogo);

            _context.SaveChanges();

            transaction.Commit();

            return RedirectToAction("Index");
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
