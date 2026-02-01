using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
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

    // GET: /Admin/Jogos
    [HttpGet("")]
    public IActionResult Index()
    {
        var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
        var usuario = _context.Usuarios.Find(usuarioId);

        if (usuario == null || !usuario.IsAdmin)
            return Forbid();

        var jogos = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .OrderBy(j => j.DataHora)
            .ToList();

        return View(jogos);
    }

    // GET: /Admin/Jogos/Editar/5
    [HttpGet("Editar/{id}")]
    public IActionResult Editar(int id)
    {
        var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
        var usuario = _context.Usuarios.Find(usuarioId);

        if (usuario == null || !usuario.IsAdmin)
            return Forbid();

        var jogo = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .FirstOrDefault(j => j.Id == id);

        if (jogo == null)
            return NotFound();

        return View(jogo);
    }

    // POST: /Admin/Jogos/Finalizar/5
    [HttpPost("Finalizar/{id}")]
    public IActionResult Finalizar(int id, int golsA, int golsB)
    {
        var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
        var usuario = _context.Usuarios.Find(usuarioId);

        if (usuario == null || !usuario.IsAdmin)
            return Forbid();

        var jogo = _jogoService.FinalizarJogo(id, golsA, golsB);

        _selecaoService.AtualizarClassificacao(jogo);
        _apostaService.RecalcularApostasPorJogo(jogo);

        return RedirectToAction("Index");
    }
}
