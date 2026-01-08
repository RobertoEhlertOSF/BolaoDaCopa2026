namespace BolaoDaCopa2026.Models
{
    using System.Collections.Generic;

    public class Selecao
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Grupo { get; set; }

        public int GolsPro { get; set; }
        public int GolsContra { get; set; }

        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
    }
}
