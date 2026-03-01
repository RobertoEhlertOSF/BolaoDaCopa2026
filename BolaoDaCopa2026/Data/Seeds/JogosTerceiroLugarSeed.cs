using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosTerceiroLugarSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Terceiro Lugar"))
                return;

            var jogoTerceiroLugar = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 18, 18, 0, 0),
                    Fase = "Terceiro Lugar",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Perd. Semifinal 1",
                    DescricaoSelecaoB = "Perd. Semifinal 2"
                }
            };

            context.Jogos.AddRange(jogoTerceiroLugar);
            context.SaveChanges();
        }
    }
}