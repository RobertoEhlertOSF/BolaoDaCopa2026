using System;
using Microsoft.AspNetCore.Mvc;
using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Identity;

namespace BolaoDaCopa2026.Controllers;

[ApiController]
[Route("")]
public class ContaController : ControllerBase
{
    // Campo privado para acessar o banco de dados
    private readonly BolaoContext _ctx;

    // Campo responsável por criptografar (hash) senhas
    private readonly IPasswordHasher<Usuario> _hasher;

    public ContaController(BolaoContext ctx, IPasswordHasher<Usuario> hasher)
    {
        _ctx = ctx;
        _hasher = hasher;
    }

    // POST /DadosCadastro (recebe do <form>)
    [HttpPost("DadosCadastro")]
    public IActionResult DadosCadastro([FromForm] CadastroFormDto dto)
    {
        // validações mínimas, se estiver em branco retorna para cadastro
        if (string.IsNullOrWhiteSpace(dto.Nome) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Senha))
        {
            return Redirect("/cadastro.html?erro=" +
                Uri.EscapeDataString("Preencha nome, email e senha."));
        }

        // normaliza o email, evita problema com letras maiusculas e minusculas
        var email = dto.Email.Trim().ToLower();

        // evita duplicar email
        var jaExiste = _ctx.Usuarios.Any(u => u.Email.ToLower() == email);
        if (jaExiste)
            return Redirect("/cadastro.html?erro=" +
                Uri.EscapeDataString("Este e-mail já está cadastrado."));

        // Somente credenciais (login)
        var usuario = new Usuario
        {
            Email = email,
            Senha = "",      // futuro criação de hash
            IsAdmin = false  // como regra, ninguém cria login como admin
        };

        // Gera o hash da senha e guarda no Usuario
        usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);

        // Apostador = dados do participante
        var apostador = new Apostador
        {
            Nome = dto.Nome.Trim(),
            DataNascimento = dto.DataNascimento,

            // dados iniciais do bolão
            IsPago = false,
            Pontuacao = 0,
            PalpitesExatos = 0,

            // ligação 1:1 (Apostador -> Usuario)
            Usuario = usuario
        };

        // Salva o apostador e o EF salva o usuario junto
        _ctx.Apostadores.Add(apostador);
        _ctx.SaveChanges();

        return Redirect("/acesso.html?msg=" +
            Uri.EscapeDataString("Cadastro realizado! Agora faça login."));
    }

    // POST /FazerLogin (recebe do <form>)
    [HttpPost("FazerLogin")]
    public IActionResult FazerLogin([FromForm] LoginFormDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
            return Redirect("/acesso.html?erro=" +
                Uri.EscapeDataString("Informe email e senha."));

        var email = dto.Email.Trim().ToLower();

        var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email);
        if (usuario is null)
            return Redirect("/acesso.html?erro=" +
                Uri.EscapeDataString("E-mail ou senha inválidos."));

        var check = _hasher.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);
        if (check == PasswordVerificationResult.Failed)
            return Redirect("/acesso.html?erro=" +
                Uri.EscapeDataString("E-mail ou senha inválidos."));

        // ✅ login ok — para testes apenas redirecionar
        return Redirect("/acesso.html?msg=" + Uri.EscapeDataString("Login realizado com sucesso!"));
    }
}

// DTO de cadastro
public class CadastroFormDto
{
    public string Nome { get; set; } = "";
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}

// DTO de login
public class LoginFormDto
{
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}