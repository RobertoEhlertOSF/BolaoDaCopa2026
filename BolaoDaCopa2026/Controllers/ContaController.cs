using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using BolaoDaCopa2026.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BolaoDaCopa2026.Controllers;

[Route("conta")]
public class ContaController : Controller
{
    private readonly BolaoContext _ctx;
    private readonly IPasswordHasher<Usuario> _hasher;
    private readonly IEmailService _emailService;

    public ContaController(
        BolaoContext ctx,
        IPasswordHasher<Usuario> hasher,
        IEmailService emailService)
    {
        _ctx = ctx;
        _hasher = hasher;
        _emailService = emailService;
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
        ViewBag.Erro = erro ?? TempData["Erro"];
        ViewBag.Msg = msg ?? TempData["Msg"];

        return View();
    }

    // POST /conta/cadastro
    [HttpPost("cadastro")]
    public IActionResult DadosCadastro(CadastroFormDto dto)
    {

        var hoje = DateTime.Today;
        var idade = hoje.Year - dto.DataNascimento.Year;

        if (dto.DataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        if (idade < 18)
        {
            return RedirectToAction(nameof(Cadastro), new
            {
                erro = "É necessário ter pelo menos 18 anos para participar."
            });
        }

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

        var usuario = _ctx.Usuarios
            .AsNoTracking()
            .FirstOrDefault(u => u.Email.ToLower() == email);
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
        HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
        HttpContext.Session.SetString("IsAdmin", usuario.IsAdmin.ToString());

        return RedirectToAction("Index", "Home");
    }

    // GET /conta/eula
    [HttpGet("eula")]
    public IActionResult Eula()
    {
        return View();
    }

    // GET /conta/esqueci-senha
    [HttpGet("esqueci-senha")]
    public IActionResult EsqueciSenha(string? erro = null, string? msg = null)
    {
        ViewBag.Erro = erro;
        ViewBag.Msg = msg;
        return View();
    }

    // POST /conta/esqueci-senha
    [HttpPost("esqueci-senha")]
    public async Task<IActionResult> EnviarLinkRedefinicao(EsqueciSenhaFormDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
        {
            return RedirectToAction(nameof(EsqueciSenha), new
            {
                erro = "Informe o e-mail."
            });
        }

        var email = dto.Email.Trim().ToLower();

        var usuario = _ctx.Usuarios
            .FirstOrDefault(u => u.Email.ToLower() == email);

        if (usuario == null)
        {
            return RedirectToAction(nameof(EsqueciSenha), new
            {
                erro = $"Não existe email {dto.Email} criado."
            });
        }

        var tokensAntigos = _ctx.PasswordResetTokens
            .Where(t =>
                t.UsuarioId == usuario.Id &&
                !t.Utilizado &&
                t.ExpiraEmUtc > DateTime.UtcNow)
            .ToList();

        foreach (var tokenAntigo in tokensAntigos)
        {
            tokenAntigo.Utilizado = true;
            tokenAntigo.UtilizadoEmUtc = DateTime.UtcNow;
        }

        var token = GerarTokenSeguro();
        var tokenHash = GerarHashDoToken(token);

        var resetToken = new PasswordResetToken
        {
            UsuarioId = usuario.Id,
            TokenHash = tokenHash,
            CriadoEmUtc = DateTime.UtcNow,
            ExpiraEmUtc = DateTime.UtcNow.AddHours(1),
            Utilizado = false
        };

        _ctx.PasswordResetTokens.Add(resetToken);
        _ctx.SaveChanges();

        var link = Url.Action(
            action: nameof(RedefinirSenha),
            controller: "Conta",
            values: new { token },
            protocol: Request.Scheme
        );

        if (string.IsNullOrWhiteSpace(link))
        {
            return RedirectToAction(nameof(EsqueciSenha), new
            {
                erro = "Não foi possível gerar o link de redefinição."
            });
        }

        var corpoEmail = $@"
        <h2>Redefinição de senha</h2>

        <p>Recebemos uma solicitação para redefinir sua senha no Bolão da Copa Nappers 2026.</p>

        <p>
            <a href=""{link}"">
                Clique aqui para redefinir sua senha
            </a>
        </p>

        <p>Este link expira em 1 hora.</p>

        <p>Se você não solicitou essa alteração, ignore este email.</p>
        <p>Veja se agora não a esqueça, por favor, não seja bobo.</p>
    ";

        await _emailService.EnviarAsync(
            usuario.Email,
            "Redefinição de senha - Bolão da Copa Nappers 2026",
            corpoEmail
        );

        return RedirectToAction(nameof(Login), new
        {
            msg = $"Enviamos um link de redefinição para {usuario.Email}."
        });
    }

    private static string GerarTokenSeguro()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return WebEncoders.Base64UrlEncode(bytes);
    }

    private static string GerarHashDoToken(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }

    // GET /conta/redefinir-senha
    [HttpGet("redefinir-senha")]
    public IActionResult RedefinirSenha(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return RedirectToAction(nameof(Login), new
            {
                erro = "Link de redefinição inválido."
            });
        }

        var tokenHash = GerarHashDoToken(token);

        var resetToken = _ctx.PasswordResetTokens
            .AsNoTracking()
            .FirstOrDefault(t =>
                t.TokenHash == tokenHash &&
                !t.Utilizado &&
                t.ExpiraEmUtc > DateTime.UtcNow);

        if (resetToken == null)
        {
            TempData["Erro"] = "Link de redefinição inválido, expirado ou já utilizado.";

            return RedirectToAction(nameof(Login));
        }
        

        var dto = new RedefinirSenhaFormDto
        {
            Token = token
        };

        return View(dto);
    }

    // POST /conta/redefinir-senha
    [HttpPost("redefinir-senha")]
    public IActionResult SalvarNovaSenha(RedefinirSenhaFormDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Token))
        {
            return RedirectToAction(nameof(Login), new
            {
                erro = "Link de redefinição inválido."
            });
        }

        if (string.IsNullOrWhiteSpace(dto.NovaSenha) ||
            string.IsNullOrWhiteSpace(dto.ConfirmarSenha))
        {
            ViewBag.Erro = "Informe e confirme a nova senha.";
            return View("RedefinirSenha", dto);
        }

        if (dto.NovaSenha.Length < 6)
        {
            ViewBag.Erro = "A senha deve ter pelo menos 6 caracteres.";
            return View("RedefinirSenha", dto);
        }

        if (dto.NovaSenha != dto.ConfirmarSenha)
        {
            ViewBag.Erro = "As senhas não conferem.";
            return View("RedefinirSenha", dto);
        }

        var tokenHash = GerarHashDoToken(dto.Token);

        var resetToken = _ctx.PasswordResetTokens
            .FirstOrDefault(t =>
                t.TokenHash == tokenHash &&
                !t.Utilizado &&
                t.ExpiraEmUtc > DateTime.UtcNow);

        if (resetToken == null)
        {
            ViewBag.Erro = "Link de redefinição inválido ou expirado.";
            return View("RedefinirSenha", dto);
        }

        var usuario = _ctx.Usuarios
            .FirstOrDefault(u => u.Id == resetToken.UsuarioId);

        if (usuario == null)
        {
            ViewBag.Erro = "Usuário não encontrado.";
            return View("RedefinirSenha", dto);
        }

        usuario.Senha = _hasher.HashPassword(usuario, dto.NovaSenha);

        resetToken.Utilizado = true;
        resetToken.UtilizadoEmUtc = DateTime.UtcNow;

        _ctx.SaveChanges();

        return RedirectToAction(nameof(Login), new
        {
            msg = "Senha redefinida com sucesso. Faça login com a nova senha."
        });
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
    public string ConfirmarSenha { get; set; } = "";
}

public class LoginFormDto
{
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}

public class EsqueciSenhaFormDto
{
    public string Email { get; set; } = "";
}

public class RedefinirSenhaFormDto
{
    public string Token { get; set; } = "";
    public string NovaSenha { get; set; } = "";
    public string ConfirmarSenha { get; set; } = "";
}