namespace BolaoDaCopa2026.ViewModels
{
    public class RankingIndexViewModel
    {
        public DateTime AtualizadoEmUtc { get; set; }
        public string? TotalPremioTexto { get; set; } // placeholder por enquanto

        public List<RankingLinhaViewModel> Linhas { get; set; } = new();
    }

    public class RankingLinhaViewModel
    {
        public int Posicao { get; set; }
        public string Nome { get; set; } = "";
        public int Pontos { get; set; }

        // NOVOS CAMPOS:
        public int DistanciaDoPrimeiro { get; set; }     
        public int PlacaresExatos { get; set; }          
    }
}