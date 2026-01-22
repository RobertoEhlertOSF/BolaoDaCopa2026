using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Pages.Jogos
{
    public class IndexModel : PageModel
    {
        private readonly BolaoContext _context;

        public List<Jogo> Jogos { get; set; } = new();

        public IndexModel(BolaoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Jogos = _context.Jogos
                .Include(j => j.SelecaoA)
                .Include(j => j.SelecaoB)
                .OrderBy(j => j.DataHora)
                .ToList();
        }
    }
}
