using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BolaoDaCopa2026.Controllers;

[Route("conta")]
public class ContaController : Controller
{
    private readonly BolaoContext _ctx;
    private readonly IPasswordHasher<Usuario> _hasher;

    public ContaController(BolaoContext ctx, IPasswordHasher<Usuario> hasher)
    {
        _ctx = ctx;
        _hasher = hasher;
    }

    // GET /conta/cadastro
    [HttpGet("cadastro")]
    public IActionResult Cadastro(string? erro = null)
    {
        ViewBag.Erro = erro;
        return View();
    }

    // GET /conta/login
    [HttpGet("login")]
    public IActionResult Login(string? erro = null, string? msg = null)
    {
        ViewBag.Erro = erro;
        ViewBag.Msg = msg;
        return View();
    }

    // POST /conta/cadastro
    [HttpPost("cadastro")]
    public IActionResult DadosCadastro(CadastroFormDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Senha))
        {
            return RedirectToAction(nameof(Cadastro), new
            {
                erro = "Preencha nome, email e senha."
            });
        }

        var email = dto.Email.Trim().ToLower();

        var jaExiste = _ctx.Usuarios.Any(u => u.Email.ToLower() == email);
        if (jaExiste)
        {
            return RedirectToAction(nameof(Cadastro), new
            {
                erro = "Este e-mail já está cadastrado."
            });
        }

        var usuario = new Usuario
        {
            Email = email,
            IsAdmin = false
        };

        usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);

        var apostador = new Apostador
        {
            Nome = dto.Nome.Trim(),
            DataNascimento = dto.DataNascimento,
            IsPago = false,
            Pontuacao = 0,
            PalpitesExatos = 0,
            Usuario = usuario
        };

        _ctx.Apostadores.Add(apostador);
        _ctx.SaveChanges();

        return RedirectToAction(nameof(Login), new
        {
            msg = "Cadastro realizado! Agora faça login."
        });
    }

    // POST /conta/login
    [HttpPost("login")]
    public IActionResult FazerLogin(LoginFormDto dto)
    {
        String erro;
        if (string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Senha))
        {
            return RedirectToAction(nameof(Login), new
            {
                erro = "Informe email e senha."
            });
        }

        var email = dto.Email.Trim().ToLower();

        var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email);
        if (usuario is null)
        {
            TempData["Erro"] = "E-mail ou senha inválidos.";

            return RedirectToAction(nameof(Login));
        }

        var check = _hasher.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);
        if (check == PasswordVerificationResult.Failed)
        {
            TempData["Erro"] = "E-mail ou senha inválidos.";

            return RedirectToAction(nameof(Login));
        }

        var apostador = _ctx.Usuarios
            .Where(u => u.Email == email)
            .Select(u => new
            {
                Id = u.Apostador.Id,
                Nome = u.Apostador.Nome
            })
            .FirstOrDefault();

        if (apostador == null)
        {
            TempData["Erro"] = "E-mail ou senha inválidos.";
            return RedirectToAction(nameof(Login));
        }

        HttpContext.Session.SetInt32("ApostadorId", apostador.Id);
        HttpContext.Session.SetString("NomeUsuario", apostador.Nome);

        return RedirectToAction("Index", "Home");
    }
}

// =========================
// DTOs
// =========================

public class CadastroFormDto
{
    public string Nome { get; set; } = "";
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}

public class LoginFormDto
{
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}
