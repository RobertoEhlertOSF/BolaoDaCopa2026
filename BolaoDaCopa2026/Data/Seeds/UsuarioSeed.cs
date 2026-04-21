using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoDaCopa2026.Data.Seeds
{
    public class UsuarioSeed
    {
        public static void Seed(BolaoContext context)
        {
            var hasher = new PasswordHasher<Usuario>();

            // 🔹 Roberto Admin
            if (!context.Usuarios.Any(u => u.Email == "roberto.admin@hotmail.com"))
            {
                var usuario = new Usuario
                {
                    Email = "roberto.admin@hotmail.com",
                    Senha = hasher.HashPassword(null, "123"),
                    IsAdmin = true
                };

                usuario.Apostador = new Apostador
                {
                    Nome = "Roberto Admin",
                    DataNascimento = new DateTime(1990, 1, 1),
                    IsPago = true,
                    PontosJogos = 0,
                    PontosCampeao = 0,
                    PalpitesExatos = 0
                };

                context.Usuarios.Add(usuario);
            }

            // 🔹 Fernando Admin
            if (!context.Usuarios.Any(u => u.Email == "fernando.admin@hotmail.com"))
            {
                var usuario = new Usuario
                {
                    Email = "fernando.admin@hotmail.com",
                    Senha = hasher.HashPassword(null, "123"),
                    IsAdmin = true
                };

                usuario.Apostador = new Apostador
                {
                    Nome = "Fernando Admin",
                    DataNascimento = new DateTime(1990, 1, 1),
                    IsPago = true,
                    PontosJogos = 0,
                    PontosCampeao = 0,
                    PalpitesExatos = 0
                };

                context.Usuarios.Add(usuario);
            }

            context.SaveChanges();
        }
    }
}