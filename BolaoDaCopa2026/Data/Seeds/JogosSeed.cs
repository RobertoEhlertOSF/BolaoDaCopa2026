using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class JogosSeed
    {

            public static void Seed(BolaoContext context)
            {
                if (context.Jogos.Any())
                    return;

            Selecao S(string nome)
            {
                var selecao = context.Selecoes
                    .FirstOrDefault(s => s.Nome == nome);

                if (selecao == null)
                    throw new Exception($"Seleção não encontrada: '{nome}'");

                return selecao;
            }


            var jogos = new List<Jogo>
        {
            // ===== Grupo A =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("México").Id,
                SelecaoBId = S("África do Sul").Id,
                DataHora = new DateTime(2026, 6, 11, 16, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Coreia do Sul").Id,
                SelecaoBId = S("Repescagem Europa D").Id,
                DataHora = new DateTime(2026, 6, 11, 23, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa D").Id,
                SelecaoBId = S("África do Sul").Id,
                DataHora = new DateTime(2026, 6, 18, 13, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("México").Id,
                SelecaoBId = S("Coreia do Sul").Id,
                DataHora = new DateTime(2026, 6, 18, 22, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa D").Id,
                SelecaoBId = S("México").Id,
                DataHora = new DateTime(2026, 6, 24, 22, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("África do Sul").Id,
                SelecaoBId = S("Coreia do Sul").Id,
                DataHora = new DateTime(2026, 6, 24, 22, 0, 0),
                Fase = "Grupo A",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo B =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Canadá").Id,
                SelecaoBId = S("Repescagem Europa A").Id,
                DataHora = new DateTime(2026, 6, 12, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Catar").Id,
                SelecaoBId = S("Suíça").Id,
                DataHora = new DateTime(2026, 6, 13, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Suíça").Id,
                SelecaoBId = S("Repescagem Europa A").Id,
                DataHora = new DateTime(2026, 6, 18, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Canadá").Id,
                SelecaoBId = S("Catar").Id,
                DataHora = new DateTime(2026, 6, 18, 19, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Suíça").Id,
                SelecaoBId = S("Canadá").Id,
                DataHora = new DateTime(2026, 6, 24, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa A").Id,
                SelecaoBId = S("Catar").Id,
                DataHora = new DateTime(2026, 6, 24, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo C =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Brasil").Id,
                SelecaoBId = S("Marrocos").Id,
                DataHora = new DateTime(2026, 6, 13, 19, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Haiti").Id,
                SelecaoBId = S("Escócia").Id,
                DataHora = new DateTime(2026, 6, 13, 22, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Escócia").Id,
                SelecaoBId = S("Marrocos").Id,
                DataHora = new DateTime(2026, 6, 19, 19, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Brasil").Id,
                SelecaoBId = S("Haiti").Id,
                DataHora = new DateTime(2026, 6, 19, 22, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Escócia").Id,
                SelecaoBId = S("Brasil").Id,
                DataHora = new DateTime(2026, 6, 24, 19, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Marrocos").Id,
                SelecaoBId = S("Haiti").Id,
                DataHora = new DateTime(2026, 6, 24, 19, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo D =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Estados Unidos").Id,
                SelecaoBId = S("Paraguai").Id,
                DataHora = new DateTime(2026, 6, 12, 22, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Austrália").Id,
                SelecaoBId = S("Repescagem Europa C").Id,
                DataHora = new DateTime(2026, 6, 13, 1, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa C").Id,
                SelecaoBId = S("Paraguai").Id,
                DataHora = new DateTime(2026, 6, 19, 1, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Estados Unidos").Id,
                SelecaoBId = S("Austrália").Id,
                DataHora = new DateTime(2026, 6, 19, 16, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa C").Id,
                SelecaoBId = S("Estados Unidos").Id,
                DataHora = new DateTime(2026, 6, 25, 23, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Paraguai").Id,
                SelecaoBId = S("Austrália").Id,
                DataHora = new DateTime(2026, 6, 25, 23, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo E =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Alemanha").Id,
                SelecaoBId = S("Curaçao").Id,
                DataHora = new DateTime(2026, 6, 14, 14, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Costa do Marfim").Id,
                SelecaoBId = S("Equador").Id,
                DataHora = new DateTime(2026, 6, 14, 20, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Alemanha").Id,
                SelecaoBId = S("Costa do Marfim").Id,
                DataHora = new DateTime(2026, 6, 20, 17, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Equador").Id,
                SelecaoBId = S("Curaçao").Id,
                DataHora = new DateTime(2026, 6, 20, 21, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Equador").Id,
                SelecaoBId = S("Alemanha").Id,
                DataHora = new DateTime(2026, 6, 25, 17, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Curaçao").Id,
                SelecaoBId = S("Costa do Marfim").Id,
                DataHora = new DateTime(2026, 6, 25, 17, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo F =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Holanda").Id,
                SelecaoBId = S("Japão").Id,
                DataHora = new DateTime(2026, 6, 14, 17, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Repescagem Europa B").Id,
                SelecaoBId = S("Tunísia").Id,
                DataHora = new DateTime(2026, 6, 14, 23, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },

             // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Holanda").Id,
                SelecaoBId = S("Repescagem Europa B").Id,
                DataHora = new DateTime(2026, 6, 20, 14, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Tunísia").Id,
                SelecaoBId = S("Japão").Id,
                DataHora = new DateTime(2026, 6, 21, 1, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Tunísia").Id,
                SelecaoBId = S("Holanda").Id,
                DataHora = new DateTime(2026, 6, 25, 20, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Japão").Id,
                SelecaoBId = S("Repescagem Europa B").Id,
                DataHora = new DateTime(2026, 6, 25, 20, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo G =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Bélgica").Id,
                SelecaoBId = S("Egito").Id,
                DataHora = new DateTime(2026, 6, 15, 16, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Irã").Id,
                SelecaoBId = S("Nova Zelândia").Id,
                DataHora = new DateTime(2026, 6, 15, 22, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Bélgica").Id,
                SelecaoBId = S("Irã").Id,
                DataHora = new DateTime(2026, 6, 21, 16, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Nova Zelândia").Id,
                SelecaoBId = S("Egito").Id,
                DataHora = new DateTime(2026, 6, 21, 22, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Nova Zelândia").Id,
                SelecaoBId = S("Bélgica").Id,
                DataHora = new DateTime(2026, 6, 27, 0, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Egito").Id,
                SelecaoBId = S("Irã").Id,
                DataHora = new DateTime(2026, 6, 27, 0, 0, 0),
                Fase = "Grupo G",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo H =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Espanha").Id,
                SelecaoBId = S("Cabo Verde").Id,
                DataHora = new DateTime(2026, 6, 15, 13, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Arábia Saudita").Id,
                SelecaoBId = S("Uruguai").Id,
                DataHora = new DateTime(2026, 6, 15, 19, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Espanha").Id,
                SelecaoBId = S("Arábia Saudita").Id,
                DataHora = new DateTime(2026, 6, 21, 13, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Uruguai").Id,
                SelecaoBId = S("Cabo Verde").Id,
                DataHora = new DateTime(2026, 6, 21, 19, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Uruguai").Id,
                SelecaoBId = S("Espanha").Id,
                DataHora = new DateTime(2026, 6, 26, 21, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Cabo Verde").Id,
                SelecaoBId = S("Arábia Saudita").Id,
                DataHora = new DateTime(2026, 6, 26, 21, 0, 0),
                Fase = "Grupo H",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo I =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("França").Id,
                SelecaoBId = S("Senegal").Id,
                DataHora = new DateTime(2026, 6, 16, 16, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Repescagem Intercontinental 2").Id,
                SelecaoBId = S("Noruega").Id,
                DataHora = new DateTime(2026, 6, 16, 19, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("França").Id,
                SelecaoBId = S("Repescagem Intercontinental 2").Id,
                DataHora = new DateTime(2026, 6, 22, 18, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Noruega").Id,
                SelecaoBId = S("Senegal").Id,
                DataHora = new DateTime(2026, 6, 22, 21, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Noruega").Id,
                SelecaoBId = S("França").Id,
                DataHora = new DateTime(2026, 6, 26, 16, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Senegal").Id,
                SelecaoBId = S("Repescagem Intercontinental 2").Id,
                DataHora = new DateTime(2026, 6, 26, 16, 0, 0),
                Fase = "Grupo I",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo J =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Argentina").Id,
                SelecaoBId = S("Argélia").Id,
                DataHora = new DateTime(2026, 6, 16, 22, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Áustria").Id,
                SelecaoBId = S("Jordânia").Id,
                DataHora = new DateTime(2026, 6, 17, 1, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Argentina").Id,
                SelecaoBId = S("Áustria").Id,
                DataHora = new DateTime(2026, 6, 22, 14, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Jordânia").Id,
                SelecaoBId = S("Argélia").Id,
                DataHora = new DateTime(2026, 6, 23, 0, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Jordânia").Id,
                SelecaoBId = S("Argentina").Id,
                DataHora = new DateTime(2026, 6, 27, 23, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Argélia").Id,
                SelecaoBId = S("Áustria").Id,
                DataHora = new DateTime(2026, 6, 27, 23, 0, 0),
                Fase = "Grupo J",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo K =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Portugal").Id,
                SelecaoBId = S("Repescagem Intercontinental 1").Id,
                DataHora = new DateTime(2026, 6, 16, 22, 0, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Uzbequistão").Id,
                SelecaoBId = S("Colômbia").Id,
                DataHora = new DateTime(2026, 6, 17, 1, 0, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Portugal").Id,
                SelecaoBId = S("Uzbequistão").Id,
                DataHora = new DateTime(2026, 6, 23, 14, 0, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Colômbia").Id,
                SelecaoBId = S("Repescagem Intercontinental 1").Id,
                DataHora = new DateTime(2026, 6, 23, 23, 0, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Colômbia").Id,
                SelecaoBId = S("Portugal").Id,
                DataHora = new DateTime(2026, 6, 27, 20, 30, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Repescagem Intercontinental 1").Id,
                SelecaoBId = S("Uzbequistão").Id,
                DataHora = new DateTime(2026, 6, 27, 20, 30, 0),
                Fase = "Grupo K",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo L =====
            // ===== 1ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Inglaterra").Id,
                SelecaoBId = S("Croácia").Id,
                DataHora = new DateTime(2026, 6, 17, 17, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Gana").Id,
                SelecaoBId = S("Panamá").Id,
                DataHora = new DateTime(2026, 6, 17, 20, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 2ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Inglaterra").Id,
                SelecaoBId = S("Gana").Id,
                DataHora = new DateTime(2026, 6, 23, 17, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Panamá").Id,
                SelecaoBId = S("Croácia").Id,
                DataHora = new DateTime(2026, 6, 23, 20, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== 3ª Rodada =====
            new Jogo
            {
                SelecaoAId = S("Panamá").Id,
                SelecaoBId = S("Inglaterra").Id,
                DataHora = new DateTime(2026, 6, 27, 18, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Croácia").Id,
                SelecaoBId = S("Gana").Id,
                DataHora = new DateTime(2026, 6, 27, 18, 0, 0),
                Fase = "Grupo L",
                Status = "Agendado",
                EstaAberto = true
            },
        };

                context.Jogos.AddRange(jogos);
                context.SaveChanges();
            }
        }

    }

