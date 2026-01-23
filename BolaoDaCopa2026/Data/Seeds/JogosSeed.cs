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
            // ===== Grupo B =====
            new Jogo
            {
                SelecaoAId = S("México").Id,
                SelecaoBId = S("África do Sul").Id,
                DataHora = new DateTime(2026, 6, 11, 16, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Coreia do Sul").Id,
                SelecaoBId = S("Repescagem Europa D").Id,
                DataHora = new DateTime(2026, 6, 11, 23, 0, 0),
                Fase = "Grupo B",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo C =====
            new Jogo
            {
                SelecaoAId = S("Canadá").Id,
                SelecaoBId = S("Repescagem Europa A").Id,
                DataHora = new DateTime(2026, 6, 12, 16, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Catar").Id,
                SelecaoBId = S("Suíça").Id,
                DataHora = new DateTime(2026, 6, 13, 16, 0, 0),
                Fase = "Grupo C",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo D =====
            new Jogo
            {
                SelecaoAId = S("Brasil").Id,
                SelecaoBId = S("Marrocos").Id,
                DataHora = new DateTime(2026, 6, 13, 19, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Haiti").Id,
                SelecaoBId = S("Escócia").Id,
                DataHora = new DateTime(2026, 6, 13, 22, 0, 0),
                Fase = "Grupo D",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo E =====
            new Jogo
            {
                SelecaoAId = S("Estados Unidos").Id,
                SelecaoBId = S("Paraguai").Id,
                DataHora = new DateTime(2026, 6, 12, 22, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Austrália").Id,
                SelecaoBId = S("Repescagem Europa C").Id,
                DataHora = new DateTime(2026, 6, 13, 1, 0, 0),
                Fase = "Grupo E",
                Status = "Agendado",
                EstaAberto = true
            },

            // ===== Grupo F =====
            new Jogo
            {
                SelecaoAId = S("Alemanha").Id,
                SelecaoBId = S("Curaçao").Id,
                DataHora = new DateTime(2026, 6, 14, 14, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            },
            new Jogo
            {
                SelecaoAId = S("Costa do Marfim").Id,
                SelecaoBId = S("Equador").Id,
                DataHora = new DateTime(2026, 6, 14, 20, 0, 0),
                Fase = "Grupo F",
                Status = "Agendado",
                EstaAberto = true
            }
        };

                context.Jogos.AddRange(jogos);
                context.SaveChanges();
            }
        }

    }

