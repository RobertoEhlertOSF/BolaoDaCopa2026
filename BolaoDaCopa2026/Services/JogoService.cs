using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;

public class JogoService
{
    private readonly BolaoContext _context;
    private readonly BolaoDaCopa2026.Services.HorarioOficialService _horarioOficialService;
    private const string StatusAgendado = "Agendado";
    private const string StatusEmAndamento = "EmAndamento";

    public JogoService(BolaoContext context, BolaoDaCopa2026.Services.HorarioOficialService horarioOficialService)
    {
        _context = context;
        _horarioOficialService = horarioOficialService;
    }

    public int AtualizarJogosAgendadosParaEmAndamento(DateTime? agora = null)
    {
        var referencia = agora ?? _horarioOficialService.ObterAgora();

        var jogosAgendadosIniciados = _context.Jogos
            .Where(j => j.Status == StatusAgendado && j.DataHora <= referencia)
            .ToList();

        if (jogosAgendadosIniciados.Count == 0)
            return 0;

        foreach (var jogo in jogosAgendadosIniciados)
        {
            jogo.Status = StatusEmAndamento;
            jogo.EstaAberto = false;
        }

        _context.SaveChanges();
        return jogosAgendadosIniciados.Count;
    }

    public Jogo FinalizarJogo(int jogoId, int golsA, int golsB, int? selecaoVencedoraId = null)
    {
        var jogo = _context.Jogos
            .Include(j => j.SelecaoA)
            .Include(j => j.SelecaoB)
            .FirstOrDefault(j => j.Id == jogoId);

        if (jogo == null)
            throw new InvalidOperationException("Jogo não encontrado.");

        if (golsA < 0 || golsB < 0)
            throw new InvalidOperationException("Placar inválido.");

        jogo.GolsSelecaoA = golsA;
        jogo.GolsSelecaoB = golsB;
        jogo.Status = "Finalizado";
        jogo.EstaAberto = false;

        jogo.SelecaoVencedoraId = DefinirSelecaoVencedora(jogo, golsA, golsB, selecaoVencedoraId);

        return jogo;
    }

    private static int? DefinirSelecaoVencedora(Jogo jogo, int golsA, int golsB, int? selecaoVencedoraId)
    {
        if (!EhFaseMataMata(jogo.Fase))
            return null;

        if (golsA > golsB)
            return jogo.SelecaoAId;

        if (golsB > golsA)
            return jogo.SelecaoBId;

        if (!selecaoVencedoraId.HasValue)
            throw new InvalidOperationException("Em jogo empatado de mata-mata, informe quem avançou.");

        if (selecaoVencedoraId.Value != jogo.SelecaoAId &&
            selecaoVencedoraId.Value != jogo.SelecaoBId)
        {
            throw new InvalidOperationException("Seleção vencedora inválida para este jogo.");
        }

        return selecaoVencedoraId.Value;
    }

    private static bool EhFaseMataMata(string? fase)
    {
        return !string.IsNullOrWhiteSpace(fase)
            && !fase.StartsWith("Grupo ", StringComparison.OrdinalIgnoreCase);
    }
}
