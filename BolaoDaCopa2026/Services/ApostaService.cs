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
            aposta.Apostador.PontosJogos -= aposta.Pontos;
            aposta.Pontos = 0; 
        }

        foreach (var aposta in apostas)
        {
            int pontos = _pontuacaoService.CalcularPontuacaoApostador(
                jogo.GolsSelecaoA.Value,
                jogo.GolsSelecaoB.Value,
                aposta.GolsSelecaoA,
                aposta.GolsSelecaoB);

            aposta.Pontos = pontos;
            aposta.Apostador.PontosJogos += pontos;
        }

        var apostadores = apostas
            .Select(a => a.Apostador)
            .Distinct()
            .ToList();

        var palpitesExatosPorApostador = _context.Apostas
            .Where(a =>
                a.GolsSelecaoA == jogo.GolsSelecaoA &&
                a.GolsSelecaoB == jogo.GolsSelecaoB)
            .GroupBy(a => a.ApostadorId)
            .Select(g => new
            {
                ApostadorId = g.Key,
                TotalExatos = g.Count()
            })
            .ToList();

        foreach (var apostador in apostadores)
        {
            var totalExatos = palpitesExatosPorApostador
                .FirstOrDefault(p => p.ApostadorId == apostador.Id);

            apostador.PalpitesExatos = totalExatos?.TotalExatos ?? 0;
        }
    }

    public void RecalcularCampeao(int campeaoId)
    {
        const int PONTOS_CAMPEAO = 10;

        var apostadores = _context.Apostadores.ToList();

        foreach (var apostador in apostadores)
        {
            apostador.PontosCampeao =
                apostador.SelecaoCampeaId == campeaoId
                ? PONTOS_CAMPEAO
                : 0;
        }

        _context.SaveChanges();
    }
}

