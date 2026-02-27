using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosSemifinalSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Semifinal"))
                return;

            var jogosSemifinal = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 14, 16, 0, 0),
                    Fase = "Semifinal",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Quartas 1",
                    DescricaoSelecaoB = "Venc. Quartas 2"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 15, 16, 0, 0),
                    Fase = "Semifinal",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Quartas 3",
                    DescricaoSelecaoB = "Venc. Quartas 4"
                }
            };

            context.Jogos.AddRange(jogosSemifinal);
            context.SaveChanges();
        }
    }
}