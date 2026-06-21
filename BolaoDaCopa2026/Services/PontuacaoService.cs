using BolaoDaCopa2026.Models;

public class PontuacaoService
{
    public int CalcularPontuacaoApostador(
        int golsRealA, int golsRealB,
        int golsPalpiteA, int golsPalpiteB)
    {
        if (golsPalpiteA == golsRealA && golsPalpiteB == golsRealB)
            return 10;

        bool realEmpate = golsRealA == golsRealB;
        bool palpiteEmpate = golsPalpiteA == golsPalpiteB;

        bool acertouA = golsPalpiteA == golsRealA;
        bool acertouB = golsPalpiteB == golsRealB;
        bool acertouUmLado = acertouA || acertouB;

        if (realEmpate)
        {
            if (palpiteEmpate)
                return 5;

            if (acertouUmLado)
                return 2;

            return 0;
        }

        bool acertouVencedor = false;

        if (!palpiteEmpate)
        {
            bool realAVenceu = golsRealA > golsRealB;
            bool palpiteAVenceu = golsPalpiteA > golsPalpiteB;

            acertouVencedor = realAVenceu == palpiteAVenceu;
        }

        if (acertouVencedor && acertouUmLado)
            return 7;

        if (acertouVencedor)
            return 5;

        if (acertouUmLado)
            return 2;

        return 0;
    }

    public int CalcularBonusMataMata(
        Jogo jogo,
        Aposta aposta)
    {
        if (!EhFaseMataMata(jogo.Fase))
            return 0;

        if (!jogo.GolsSelecaoA.HasValue || !jogo.GolsSelecaoB.HasValue)
            return 0;

        var vencedorRealId = ObterVencedorDoJogo(
            jogo.SelecaoAId,
            jogo.SelecaoBId,
            jogo.GolsSelecaoA.Value,
            jogo.GolsSelecaoB.Value,
            jogo.SelecaoVencedoraId);

        var vencedorApostaId = ObterVencedorDoJogo(
            aposta.SelecaoAId,
            aposta.SelecaoBId,
            aposta.GolsSelecaoA,
            aposta.GolsSelecaoB,
            aposta.SelecaoVencedoraId);

        if (!vencedorRealId.HasValue || !vencedorApostaId.HasValue)
            return 0;

        if (vencedorRealId.Value != vencedorApostaId.Value)
            return 0;

        return ObterBonusPorFase(jogo.Fase);
    }

    public void AtualizarPontuacaoSelecao(Selecao selecao, int golsMarcados, int golsSofridos)
    {
        selecao.GolsPro += golsMarcados;
        selecao.GolsContra += golsSofridos;

        if (golsMarcados > golsSofridos)
        {
            selecao.Vitorias++;
            selecao.Pontos += 3;
        }
        else if (golsMarcados == golsSofridos)
        {
            selecao.Empates++;
            selecao.Pontos += 1;
        }
        else
        {
            selecao.Derrotas++;
        }
    }

    private static int? ObterVencedorDoJogo(
        int? selecaoAId,
        int? selecaoBId,
        int golsA,
        int golsB,
        int? selecaoVencedoraId)
    {
        if (golsA > golsB)
            return selecaoAId;

        if (golsB > golsA)
            return selecaoBId;

        return selecaoVencedoraId;
    }

    private static int ObterBonusPorFase(string? fase)
    {
        return fase?.Trim().ToLowerInvariant() switch
        {
            "segunda fase" => 1,
            "oitavas" => 1,
            "quartas" => 2,
            "semifinal" => 2,
            "final" => 3,
            _ => 0
        };
    }

    private static bool EhFaseMataMata(string? fase)
    {
        return !string.IsNullOrWhiteSpace(fase)
            && !fase.StartsWith("Grupo ", StringComparison.OrdinalIgnoreCase);
    }
}


