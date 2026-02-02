
    namespace BolaoDaCopa2026.Models
    {
        public class Jogo
        {
            public int Id { get; set; }
            
            public int SelecaoAId { get; set; }
            public Selecao SelecaoA { get; set; }
            
            public int SelecaoBId { get; set; }
            public Selecao SelecaoB { get; set; }

            public Boolean EstaAberto { get; set; }


            public DateTime DataHora { get; set; }
            public string Fase { get; set; }
            public string Status { get; set; }
            
            public int? GolsSelecaoA { get; set; }
            public int? GolsSelecaoB { get; set; }
            
            public bool ApostasProcessadas { get; set; }
            public bool ClassificacaoProcessada { get; set; }


    }
    }
