using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Pages.Jogos
{
    public class IndexModel : PageModel
    {
        private readonly BolaoContext _context;
        private readonly JogoService _jogoService;

        public List<Jogo> Jogos { get; set; } = new();

        public IndexModel(BolaoContext context, JogoService jogoService)
        {
            _context = context;
            _jogoService = jogoService;
        }

        public void OnGet()
        {
            _jogoService.AtualizarJogosAgendadosParaEmAndamento();

            Jogos = _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .OrderBy(j => j.DataHora)
                .ToList();
        }
    }
}
