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
            int pontosBase = _pontuacaoService.CalcularPontuacaoApostador(
                jogo.GolsSelecaoA.Value,
                jogo.GolsSelecaoB.Value,
                aposta.GolsSelecaoA,
                aposta.GolsSelecaoB);

            int bonusMataMata = _pontuacaoService.CalcularBonusMataMata(jogo, aposta);

            int pontos = pontosBase + bonusMataMata;

            aposta.Pontos = pontos;
            aposta.Apostador.PontosJogos += pontos;
        }

        var apostadorIds = apostas
            .Select(a => a.ApostadorId)
            .Distinct()
            .ToList();

        AtualizarPalpitesExatosDosApostadores(apostadorIds);
    }

    public void RecalcularTudo()
    {
        var jogosFinalizados = _context.Jogos
            .Where(j => j.Status == "Finalizado" && j.GolsSelecaoA.HasValue && j.GolsSelecaoB.HasValue)
            .ToDictionary(j => j.Id);

        var pontosJogosPorApostador = new Dictionary<int, int>();
        var exatosPorApostador = new Dictionary<int, int>();

        var apostas = _context.Apostas.ToList();

        foreach (var aposta in apostas)
        {
            var pontos = 0;

            if (jogosFinalizados.TryGetValue(aposta.JogoId, out var jogo))
            {
                int pontosBase = _pontuacaoService.CalcularPontuacaoApostador(
                    jogo.GolsSelecaoA!.Value,
                    jogo.GolsSelecaoB!.Value,
                    aposta.GolsSelecaoA,
                    aposta.GolsSelecaoB);

                int bonusMataMata = _pontuacaoService.CalcularBonusMataMata(jogo, aposta);

                pontos = pontosBase + bonusMataMata;
            }

            aposta.Pontos = pontos;

            if (!pontosJogosPorApostador.ContainsKey(aposta.ApostadorId))
                pontosJogosPorApostador[aposta.ApostadorId] = 0;

            pontosJogosPorApostador[aposta.ApostadorId] += pontos;

            if (jogosFinalizados.TryGetValue(aposta.JogoId, out var jogoExato) &&
                aposta.GolsSelecaoA == jogoExato.GolsSelecaoA &&
                aposta.GolsSelecaoB == jogoExato.GolsSelecaoB)
            {
                if (!exatosPorApostador.ContainsKey(aposta.ApostadorId))
                    exatosPorApostador[aposta.ApostadorId] = 0;

                exatosPorApostador[aposta.ApostadorId] += 1;
            }
        }

        var apostadores = _context.Apostadores.ToList();

        foreach (var apostador in apostadores)
        {
            apostador.PontosJogos = pontosJogosPorApostador.GetValueOrDefault(apostador.Id, 0);
            apostador.PalpitesExatos = exatosPorApostador.GetValueOrDefault(apostador.Id, 0);
        }
    }

    private void AtualizarPalpitesExatosDosApostadores(List<int> apostadorIds)
    {
        if (apostadorIds == null || apostadorIds.Count == 0)
            return;

        var exatosPorApostador = _context.Apostas
            .Where(a => apostadorIds.Contains(a.ApostadorId))
            .Where(a =>
                a.Jogo.Status == "Finalizado" &&
                a.Jogo.GolsSelecaoA.HasValue &&
                a.Jogo.GolsSelecaoB.HasValue &&
                a.GolsSelecaoA == a.Jogo.GolsSelecaoA.Value &&
                a.GolsSelecaoB == a.Jogo.GolsSelecaoB.Value)
            .GroupBy(a => a.ApostadorId)
            .Select(g => new
            {
                ApostadorId = g.Key,
                TotalExatos = g.Count()
            })
            .ToDictionary(x => x.ApostadorId, x => x.TotalExatos);

        var apostadores = _context.Apostadores
            .Where(a => apostadorIds.Contains(a.Id))
            .ToList();

        foreach (var apostador in apostadores)
        {
            apostador.PalpitesExatos = exatosPorApostador.GetValueOrDefault(apostador.Id, 0);
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
