using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosSegundaFaseSeed
    {
        public static void Seed(BolaoContext context)
        {
            if (context.Jogos.Any(j => j.Fase == "Segunda Fase"))
                return;

            var jogosSegundaFase = new List<Jogo>
            {
                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 29, 17, 30, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º E",
                    DescricaoSelecaoB = "3º A/B/C/D/F"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 30, 18, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º I",
                    DescricaoSelecaoB = "3º C/D/F/G/H"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 28, 16, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "2º A",
                    DescricaoSelecaoB = "2º B"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 29, 22, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º F",
                    DescricaoSelecaoB = "2º C"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 2, 20, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "2º K",
                    DescricaoSelecaoB = "2º L"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 2, 16, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º H",
                    DescricaoSelecaoB = "2º J"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 1, 21, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º D",
                    DescricaoSelecaoB = "3º B/E/F/I/J"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 1, 17, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º G",
                    DescricaoSelecaoB = "3º A/E/H/I/J"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 29, 14, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º C",
                    DescricaoSelecaoB = "2º F"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 30, 14, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "2º E",
                    DescricaoSelecaoB = "2º I"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 6, 30, 22, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º A",
                    DescricaoSelecaoB = "3º C/E/F/H/I"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 1, 13, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º L",
                    DescricaoSelecaoB = "3º E/H/I/J/K"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 3, 19, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º J",
                    DescricaoSelecaoB = "2º H"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 3, 15, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "2º D",
                    DescricaoSelecaoB = "2º G"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 3, 0, 0, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º B",
                    DescricaoSelecaoB = "3º E/F/G/I/J"
                },

                new Jogo
                {
                    DataHora = new DateTime(2026, 7, 3, 22, 30, 0),
                    Fase = "Segunda Fase",
                    Status = "Aguardando definição",
                    EstaAberto = false,
                    DescricaoSelecaoA = "1º K",
                    DescricaoSelecaoB = "3º D/E/I/L"
                }
            };

            context.Jogos.AddRange(jogosSegundaFase);
            context.SaveChanges();
        }
    }
}
