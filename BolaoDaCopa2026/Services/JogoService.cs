using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;

public class JogoService
{
    private readonly BolaoContext _context;
    private readonly SelecaoService _selecaoService;
    private readonly ApostaService _apostaService;

    public JogoService(
        BolaoContext context,
        SelecaoService selecaoService,
        ApostaService apostaService)
    {
        _context = context;
        _selecaoService = selecaoService;
        _apostaService = apostaService;
    }

    public Jogo FinalizarJogo(int jogoId, int golsA, int golsB)
    {
        var jogo = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .FirstOrDefault(j => j.Id == jogoId);

        if (jogo == null)
            throw new InvalidOperationException("Jogo não encontrado.");

        if (jogo.Status == "Finalizado")
            return jogo; // idempotência

        jogo.GolsSelecaoA = golsA;
        jogo.GolsSelecaoB = golsB;
        jogo.Status = "Finalizado";
        jogo.EstaAberto = false;

        _context.SaveChanges();

        return jogo;
    }

}
