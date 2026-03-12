namespace BolaoDaCopa2026.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<JogoComApostaViewModel> Jogos { get; set; } = new();

        public bool TemJogosHoje { get; set; }
    }
}