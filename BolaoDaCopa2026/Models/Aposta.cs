namespace BolaoDaCopa2026.Models
{
    public class Aposta
    {
        public int Id { get; set; }

        public Selecao SelecaoA { get; set; }
        public Selecao SelecaoB { get; set; }
        public int GolsSelecaoA { get; set; }
        public int GolsSelecaoB { get; set; }

        public int ApostadorId { get; set; }
        public Apostador Apostador { get; set; }
    }

}
