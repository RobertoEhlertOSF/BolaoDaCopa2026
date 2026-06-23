using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BolaoDaCopa2026.Data.Seeds
{
    public static class TesteFuncionalSeed
    {
        public static void Seed(BolaoContext context)
        {
            var hasher = new PasswordHasher<Usuario>();
            var usuariosTeste = new List<Usuario>();

            for (var i = 1; i <= 5; i++)
            {
                var email = $"teste{i}@funcional.local";
                var nome = $"Teste {i}";

                var usuario = context.Usuarios
                    .Include(u => u.Apostador)
                    .FirstOrDefault(u => u.Email == email);

                if (usuario == null)
                {
                    usuario = new Usuario
                    {
                        Email = email,
                        Senha = hasher.HashPassword(new Usuario { Email = email }, "123"),
                        IsAdmin = false,
                        Apostador = new Apostador
                        {
                            Nome = nome,
                            DataNascimento = new DateTime(1995, i, Math.Min(20, DateTime.DaysInMonth(1995, i))),
                            IsPago = true,
                            PontosJogos = 0,
                            PontosCampeao = 0,
                            PalpitesExatos = 0
                        }
                    };

                    context.Usuarios.Add(usuario);
                }
                else
                {
                    usuario.IsAdmin = false;
                    if (usuario.Apostador == null)
                    {
                        usuario.Apostador = new Apostador
                        {
                            Nome = nome,
                            DataNascimento = new DateTime(1995, i, Math.Min(20, DateTime.DaysInMonth(1995, i))),
                            IsPago = true,
                            PontosJogos = 0,
                            PontosCampeao = 0,
                            PalpitesExatos = 0
                        };
                    }
                    else
                    {
                        usuario.Apostador.Nome = nome;
                        usuario.Apostador.DataNascimento = new DateTime(1995, i, Math.Min(20, DateTime.DaysInMonth(1995, i)));
                    }
                }

                usuariosTeste.Add(usuario);
            }

            context.SaveChanges();

            var apostadores = usuariosTeste
                .Select(u => u.Apostador)
                .Where(a => a != null)
                .ToList();

            var jogosFaseGrupos = context.Jogos
                .Where(j =>
                    j.Fase != null &&
                    j.Fase.StartsWith("Grupo") &&
                    j.SelecaoAId.HasValue &&
                    j.SelecaoBId.HasValue)
                .OrderBy(j => j.DataHora)
                .ThenBy(j => j.Id)
                .ToList();

            foreach (var apostador in apostadores)
            {
                var indiceApostador = apostador.Id;

                foreach (var jogo in jogosFaseGrupos)
                {
                    var (golsA, golsB) = GerarPlacar(jogo.Id, indiceApostador);
                    var apostaExistente = context.Apostas
                        .FirstOrDefault(a => a.ApostadorId == apostador.Id && a.JogoId == jogo.Id);

                    if (apostaExistente == null)
                    {
                        var salt = ApostaHashService.GerarSalt();
                        var hashPayload = ApostaHashService.GerarPayload(jogo.Id, apostador.Id, golsA, golsB, null);
                        var hash = ApostaHashService.GerarHash(hashPayload, salt);

                        context.Apostas.Add(new Aposta
                        {
                            JogoId = jogo.Id,
                            SelecaoAId = jogo.SelecaoAId!.Value,
                            SelecaoBId = jogo.SelecaoBId!.Value,
                            GolsSelecaoA = golsA,
                            GolsSelecaoB = golsB,
                            ApostadorId = apostador.Id,
                            Pontos = 0,
                            Salt = salt,
                            HashCommit = hash,
                            CriadoEmUtc = DateTime.UtcNow,
                            AtualizadoEmUtc = DateTime.UtcNow
                        });

                        continue;
                    }

                    apostaExistente.SelecaoAId = jogo.SelecaoAId!.Value;
                    apostaExistente.SelecaoBId = jogo.SelecaoBId!.Value;
                    apostaExistente.GolsSelecaoA = golsA;
                    apostaExistente.GolsSelecaoB = golsB;
                    apostaExistente.HashCommit = ApostaHashService.GerarHash(
                        ApostaHashService.GerarPayload(jogo.Id, apostador.Id, golsA, golsB, null),
                        apostaExistente.Salt);
                    apostaExistente.AtualizadoEmUtc = DateTime.UtcNow;
                }
            }

            context.SaveChanges();
        }

        private static (int golsA, int golsB) GerarPlacar(int jogoId, int apostadorId)
        {
            var baseA = (jogoId + apostadorId) % 5;
            var baseB = ((jogoId * 2) + apostadorId) % 5;
            var tipo = (jogoId + apostadorId) % 3; // 0 empate, 1 vitoria A, 2 vitoria B

            if (tipo == 0)
            {
                var gols = (baseA + baseB) % 5;
                return (gols, gols);
            }

            if (tipo == 1)
            {
                var golsA = Math.Max(baseA, baseB);
                var golsB = Math.Min(baseA, baseB);

                if (golsA == golsB)
                {
                    if (golsA < 4)
                    {
                        golsA++;
                    }
                    else
                    {
                        golsB--;
                    }
                }

                return (Math.Clamp(golsA, 0, 4), Math.Clamp(golsB, 0, 4));
            }

            var golsSelecaoA = Math.Min(baseA, baseB);
            var golsSelecaoB = Math.Max(baseA, baseB);

            if (golsSelecaoA == golsSelecaoB)
            {
                if (golsSelecaoB < 4)
                {
                    golsSelecaoB++;
                }
                else
                {
                    golsSelecaoA--;
                }
            }

            return (Math.Clamp(golsSelecaoA, 0, 4), Math.Clamp(golsSelecaoB, 0, 4));
        }
    }
}

