using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosOitavasSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Oitavas"))
                return;

            var jogosOitavas = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 4, 18, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 1",
                    DescricaoSelecaoB = "Venc. Segunda fase 2"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 4, 14, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 3",
                    DescricaoSelecaoB = "Venc. Segunda fase 4"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 6, 16, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 5",
                    DescricaoSelecaoB = "Venc. Segunda fase 6"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 6, 21, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 7",
                    DescricaoSelecaoB = "Venc. Segunda fase 8"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 5, 17, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 9",
                    DescricaoSelecaoB = "Venc. Segunda fase 10"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 5, 21, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 11",
                    DescricaoSelecaoB = "Venc. Segunda fase 12"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 7, 13, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 13",
                    DescricaoSelecaoB = "Venc. Segunda fase 14"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 7, 17, 0, 0),
                    Fase = "Oitavas",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "Venc. Segunda fase 15",
                    DescricaoSelecaoB = "Venc. Segunda fase 16"
                }
            };

            context.Jogos.AddRange(jogosOitavas);
            context.SaveChanges();
        }
    }
}