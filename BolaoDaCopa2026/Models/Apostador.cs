namespace BolaoDaCopa2026.Models
{
    using System;
    using System.Collections.Generic;

    public class Apostador
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public DateTime DataNascimento { get; set; }

        public Usuario Usuario { get; set; }

        public bool IsPago { get; set; }

        public int Pontuacao { get; set; }
        public int PalpitesExatos { get; set; }

        public ICollection<Aposta> Apostas { get; set; }
    }

}
