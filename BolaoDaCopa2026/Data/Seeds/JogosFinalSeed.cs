using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosFinalSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Final"))
                return;

            var jogoFinal = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 19, 16, 0, 0),
                    Fase = "Final",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Semifinal 1",
                    DescricaoSelecaoB = "Venc. Semifinal 2"
                }
            };

            context.Jogos.AddRange(jogoFinal);
            context.SaveChanges();
        }
    }
}
