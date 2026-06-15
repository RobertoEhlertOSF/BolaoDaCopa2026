using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.ViewModels
{
    public class DefinirCampeaoAdminViewModel
    {
        public List<Selecao> Selecoes { get; set; } = new();
        public List<CampeaoApostadorAdminViewModel> Apostadores { get; set; } = new();
    }

    public class CampeaoApostadorAdminViewModel
    {
        public int ApostadorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? SelecaoCampeaId { get; set; }
        public string CampeaoAtualNome { get; set; } = "Nao definido";
    }
}
