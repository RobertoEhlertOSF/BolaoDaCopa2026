using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ApostaService
{
    private readonly BolaoContext _context;
    private readonly PontuacaoService _pontuacaoService;

    public ApostaService(BolaoContext context, PontuacaoService pontuacaoService)
    {
        _context = context;
        _pontuacaoService = pontuacaoService;
    }

    public void RecalcularApostasPorJogo(Jogo jogo)
    {
        if (!jogo.GolsSelecaoA.HasValue || !jogo.GolsSelecaoB.HasValue)
            return;

        var apostas = _context.Apostas
            .Include(a => a.Apostador)
            .Where(a => a.JogoId == jogo.Id)
            .ToList();

        foreach (var aposta in apostas)
        {
            // calcula pontos usando seu service
            int pontos = _pontuacaoService.CalcularPontuacaoApostador(
                jogo.GolsSelecaoA.Value,
                jogo.GolsSelecaoB.Value,
                aposta.GolsSelecaoA,
                aposta.GolsSelecaoB);

            aposta.Pontos = pontos; // armazenar pontos na aposta
            aposta.Apostador.Pontuacao += pontos;

            if (aposta.GolsSelecaoA == jogo.GolsSelecaoA && aposta.GolsSelecaoB == jogo.GolsSelecaoB)
            {
                aposta.Apostador.PalpitesExatos++;
            }
        }

        _context.SaveChanges();
    }
}
