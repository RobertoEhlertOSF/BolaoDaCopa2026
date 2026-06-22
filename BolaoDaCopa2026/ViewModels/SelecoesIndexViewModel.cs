using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.ViewModels
{
    public class SelecoesIndexViewModel
    {
        public string VisaoAtual { get; set; } = "grupos";
        public List<GrupoClassificacaoViewModel> Grupos { get; set; } = new();
        public List<FaseMataMataViewModel> FasesMataMata { get; set; } = new();
    }

    public class GrupoClassificacaoViewModel
    {
        public string NomeGrupo { get; set; } = string.Empty;
        public List<Selecao> Selecoes { get; set; } = new();
    }

    public class FaseMataMataViewModel
    {
        public string NomeFase { get; set; } = string.Empty;
        public string Rotulo { get; set; } = string.Empty;
        public List<JogoMataMataViewModel> Jogos { get; set; } = new();
    }

    public class JogoMataMataViewModel
    {
        public int Id { get; set; }
        public string NomeSelecaoA { get; set; } = string.Empty;
        public string NomeSelecaoB { get; set; } = string.Empty;
        public string? BandeiraSelecaoA { get; set; }
        public string? BandeiraSelecaoB { get; set; }
        public string? OrigemSelecaoA { get; set; }
        public string? OrigemSelecaoB { get; set; }
        public DateTime DataHora { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? GolsSelecaoA { get; set; }
        public int? GolsSelecaoB { get; set; }
        public string? NomeVencedor { get; set; }
    }
}
