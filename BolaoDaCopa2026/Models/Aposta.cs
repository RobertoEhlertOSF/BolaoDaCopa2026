namespace BolaoDaCopa2026.Models
{
    public class Aposta
    {
        public int Id { get; set; }

        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }

        public int SelecaoAId { get; set; }
        public int SelecaoBId { get; set; }

        public Selecao SelecaoA { get; set; }
        public Selecao SelecaoB { get; set; }

        public int GolsSelecaoA { get; set; }
        public int GolsSelecaoB { get; set; }

        // Para o mata-mata, para eu relembrar
        
        public int? SelecaoVencedoraId { get; set; }
        public Selecao? SelecaoVencedora { get; set; }

        public int ApostadorId { get; set; }
        public Apostador Apostador { get; set; }

        public int Pontos { get; set; }

        public string HashCommit { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;

        public DateTime CriadoEmUtc { get; set; }
        public DateTime AtualizadoEmUtc { get; set; }
    }
}
