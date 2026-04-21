using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Models.ViewModels
{
    public class ApostasDoJogoViewModel
    {
        public Jogo Jogo { get; set; } = null!;
        public List<ApostaJogadorItemViewModel> ApostasPorJogador { get; set; } = new();
    }

    public class ApostaJogadorItemViewModel
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public int? GolsSelecaoA { get; set; }
        public int? GolsSelecaoB { get; set; }
        public bool EsqueceuApostar => !GolsSelecaoA.HasValue || !GolsSelecaoB.HasValue;
    }
}
