
    using System;
    using System.Collections.Generic;

    namespace BolaoDaCopa2026.Models
    {
        public class Jogo
        {
            private static readonly HashSet<string> FasesMataMata = new(StringComparer.OrdinalIgnoreCase)
            {
                "Oitavas de Final",
                "Quartas de Final",
                "Semifinal",
                "Final"
            };

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

            public int? GolsProrrogacaoA { get; set; }
            public int? GolsProrrogacaoB { get; set; }

            public int? SelecaoVencedoraPenaltisId { get; set; }
            public Selecao SelecaoVencedoraPenaltis { get; set; }

            public bool ApostasProcessadas { get; set; }
            public bool ClassificacaoProcessada { get; set; }

            public bool IsMataMata()
            {
                return !string.IsNullOrWhiteSpace(Fase) && FasesMataMata.Contains(Fase.Trim());
            }

            public int? ObterVencedorId()
            {
                if (!GolsSelecaoA.HasValue || !GolsSelecaoB.HasValue)
                    return null;

                var totalA = GolsSelecaoA.Value + (GolsProrrogacaoA ?? 0);
                var totalB = GolsSelecaoB.Value + (GolsProrrogacaoB ?? 0);

                if (totalA > totalB)
                    return SelecaoAId;
                if (totalB > totalA)
                    return SelecaoBId;

                return SelecaoVencedoraPenaltisId;
            }
    }
    }
