using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosQuartasSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Quartas"))
                return;

            var jogosQuartas = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 9, 17, 0, 0),
                    Fase = "Quartas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Oitavas 1",
                    DescricaoSelecaoB = "Venc. Oitavas 2"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 10, 16, 0, 0),
                    Fase = "Quartas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Oitavas 3",
                    DescricaoSelecaoB = "Venc. Oitavas 4"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 11, 18, 0, 0),
                    Fase = "Quartas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Oitavas 5",
                    DescricaoSelecaoB = "Venc. Oitavas 6"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 11, 22, 0, 0),
                    Fase = "Quartas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Oitavas 7",
                    DescricaoSelecaoB = "Venc. Oitavas 8"
                }
            };

            context.Jogos.AddRange(jogosQuartas);
            context.SaveChanges();
        }
    }
}