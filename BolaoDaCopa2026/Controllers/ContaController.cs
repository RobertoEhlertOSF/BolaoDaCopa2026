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
            return Redirect("/cadastro.html?erro=Preencha%20nome,%20email%20e%20senha.");
        }

        // normaliza o email, evita problema com letras maiusculas e minusculas
        var email = dto.Email.Trim().ToLower();

        // evita duplicar email
        var jaExiste = _ctx.Usuarios.Any(u => u.Email.ToLower() == email);
        if (jaExiste)
            return Redirect("/cadastro.html?erro=Este%20e-mail%20já%20está%20cadastrado.");

        var usuario = new Usuario
        {
            Nome = dto.Nome.Trim(),
            DataNascimento = dto.DataNascimento,
            Email = dto.Email.Trim(),
            //TODO: Implementar HASH F0019
            Senha = ""
        };

        usuario.Senha = _hasher.HashPassword(usuario, dto.Senha);

        _ctx.Usuarios.Add(usuario);
        _ctx.SaveChanges();

        return Redirect("/acesso.html?msg=Cadastro%20realizado!%20Agora%20faça%20login.");
    }

    // POST /FazerLogin (recebe do <form>)
    [HttpPost("FazerLogin")]
    public IActionResult FazerLogin([FromForm] LoginFormDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
            return Redirect("/acesso.html?erro=Informe%20email%20e%20senha.");

        var email = dto.Email.Trim().ToLower();

        var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email);
        if (usuario is null)
            return Redirect("/acesso.html?erro=E-mail%20ou%20senha%20inválidos.");

        var check = _hasher.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);
        if (check == PasswordVerificationResult.Failed)
            return Redirect("/acesso.html?erro=E-mail%20ou%20senha%20inválidos.");

        // ✅ login ok — para testes apenas redirecionar
        
        return Redirect("/index.html"); // ou a página que for o "home" do bolão
    }
}

//DTO de cadastro
public class CadastroFormDto
{
    public string Nome { get; set; } = "";
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}

//DTO de login
public class LoginFormDto
{
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
}
