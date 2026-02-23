using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.ViewModels
{
    public class JogoAdminVM
    {
        public int Id { get; set; }

        public int? SelecaoAId { get; set; }
        public int? SelecaoBId { get; set; }

        public string? DescricaoSelecaoA { get; set; }  
        public string? DescricaoSelecaoB { get; set; }

        public List<Selecao> TodasSelecoes { get; set; } = new();
    }
}
