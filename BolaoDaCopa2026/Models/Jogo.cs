
namespace BolaoDaCopa2026.Models
{
    public class Jogo
    {
        public int Id { get; set; }

        public Selecao SelecaoA { get; set; }
        public Selecao SelecaoB { get; set; }

        public DateTime DataHora { get; set; }

        public string Fase { get; set; } // Grupos, Oitavas, Quartas, etc
        public string Status { get; set; } // Aberto | Encerrado

        public int? GolsSelecaoA { get; set; } // resultado real
        public int? GolsSelecaoB { get; set; }
    }
}
