using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace BolaoDaCopa2026.Data.Seeds
{
    public static class UsuarioSeed
    {
        private const int TamanhoMinimoSenhaAdmin = 8;

        public static void Seed(
            BolaoContext context,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            IPasswordHasher<Usuario> hasher)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(configuration);
            ArgumentNullException.ThrowIfNull(environment);
            ArgumentNullException.ThrowIfNull(hasher);

            var adminsConfigurados = ObterAdminsConfigurados(configuration);
            ValidarConfiguracaoAdmins(adminsConfigurados);

            var emailsConfigurados = adminsConfigurados
                .Select(a => a.EmailNormalizado)
                .ToList();

            var usuariosExistentes = context.Usuarios
                .Include(u => u.Apostador)
                .Where(u => emailsConfigurados.Contains(u.Email.ToLower()))
                .ToDictionary(u => u.Email.ToLower(), u => u);

            var faltandoCriacao = adminsConfigurados
                .Where(a => !usuariosExistentes.ContainsKey(a.EmailNormalizado))
                .ToList();

            var senhaAdmin = ObterSenhaAdmin(configuration);

            if (faltandoCriacao.Count > 0 &&
                string.IsNullOrWhiteSpace(senhaAdmin))
            {
                var ambiente = environment.IsProduction() ? "producao" : environment.EnvironmentName;
                throw new InvalidOperationException(
                    $"Nao foi possivel criar usuarios admin no seed ({ambiente}) porque a senha nao foi configurada. " +
                    "Defina AdminSeed__Password (ou ADMIN_SEED_PASSWORD) antes de iniciar a aplicacao.");
            }

            if (!string.IsNullOrWhiteSpace(senhaAdmin) &&
                senhaAdmin.Trim().Length < TamanhoMinimoSenhaAdmin)
            {
                throw new InvalidOperationException(
                    $"A senha dos admins no seed precisa ter pelo menos {TamanhoMinimoSenhaAdmin} caracteres.");
            }

            var alterou = false;

            foreach (var admin in adminsConfigurados)
            {
                usuariosExistentes.TryGetValue(admin.EmailNormalizado, out var usuarioExistente);

                if (usuarioExistente == null)
                {
                    var novoUsuario = new Usuario
                    {
                        Email = admin.EmailNormalizado,
                        IsAdmin = true,
                        Apostador = CriarApostadorAdmin(admin.Nome)
                    };

                    novoUsuario.Senha = hasher.HashPassword(novoUsuario, senhaAdmin!.Trim());

                    context.Usuarios.Add(novoUsuario);
                    alterou = true;
                    continue;
                }

                if (!usuarioExistente.IsAdmin)
                {
                    usuarioExistente.IsAdmin = true;
                    alterou = true;
                }

                if (!string.Equals(usuarioExistente.Email, admin.EmailNormalizado, StringComparison.Ordinal))
                {
                    usuarioExistente.Email = admin.EmailNormalizado;
                    alterou = true;
                }

                if (usuarioExistente.Apostador == null)
                {
                    usuarioExistente.Apostador = CriarApostadorAdmin(admin.Nome);
                    alterou = true;
                    continue;
                }

                if (!string.Equals(usuarioExistente.Apostador.Nome, admin.Nome, StringComparison.Ordinal))
                {
                    usuarioExistente.Apostador.Nome = admin.Nome;
                    alterou = true;
                }
            }

            if (alterou)
            {
                context.SaveChanges();
            }
        }

        private static List<AdminConfigurado> ObterAdminsConfigurados(IConfiguration configuration)
        {
            return configuration
                .GetSection("AdminSeed:Users")
                .GetChildren()
                .Select(section => new AdminConfigurado(
                    section["Email"],
                    section["Nome"]))
                .ToList();
        }

        private static string? ObterSenhaAdmin(IConfiguration configuration)
        {
            var senhaConfigurada = configuration["AdminSeed:Password"];

            if (!string.IsNullOrWhiteSpace(senhaConfigurada))
            {
                return senhaConfigurada;
            }

            return Environment.GetEnvironmentVariable("ADMIN_SEED_PASSWORD");
        }

        private static void ValidarConfiguracaoAdmins(List<AdminConfigurado> adminsConfigurados)
        {
            if (adminsConfigurados.Count == 0)
            {
                throw new InvalidOperationException(
                    "Nenhum usuario admin foi configurado no seed. Configure AdminSeed:Users no appsettings.");
            }

            var validatorEmail = new EmailAddressAttribute();
            var emailsRepetidos = new HashSet<string>();

            foreach (var admin in adminsConfigurados)
            {
                if (string.IsNullOrWhiteSpace(admin.EmailNormalizado))
                {
                    throw new InvalidOperationException(
                        "Todo admin configurado no seed precisa ter e-mail.");
                }

                if (!validatorEmail.IsValid(admin.EmailNormalizado))
                {
                    throw new InvalidOperationException(
                        $"O e-mail '{admin.EmailOriginal}' configurado no seed e invalido.");
                }

                if (string.IsNullOrWhiteSpace(admin.Nome))
                {
                    throw new InvalidOperationException(
                        $"O admin '{admin.EmailOriginal}' precisa ter nome configurado.");
                }

                if (!emailsRepetidos.Add(admin.EmailNormalizado))
                {
                    throw new InvalidOperationException(
                        $"O e-mail '{admin.EmailOriginal}' esta duplicado na configuracao de admins.");
                }
            }
        }

        private static Apostador CriarApostadorAdmin(string nome)
        {
            return new Apostador
            {
                Nome = nome,
                DataNascimento = new DateTime(1990, 1, 1),
                IsPago = true,
                PontosJogos = 0,
                PontosCampeao = 0,
                PalpitesExatos = 0
            };
        }

        private sealed class AdminConfigurado
        {
            public AdminConfigurado(string? email, string? nome)
            {
                EmailOriginal = email?.Trim() ?? string.Empty;
                EmailNormalizado = EmailOriginal.ToLowerInvariant();
                Nome = nome?.Trim() ?? string.Empty;
            }

            public string EmailOriginal { get; }
            public string EmailNormalizado { get; }
            public string Nome { get; }
        }
    }
}
