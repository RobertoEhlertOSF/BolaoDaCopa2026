using BolaoDaCopa2026.Models;

public class PontuacaoService
{
    public int CalcularPontuacaoApostador(
        int golsRealA, int golsRealB,
        int golsPalpiteA, int golsPalpiteB)
    {
        // Placar exato
        if (golsPalpiteA == golsRealA && golsPalpiteB == golsRealB)
            return 10;

        bool realEmpate = golsRealA == golsRealB;
        bool palpiteEmpate = golsPalpiteA == golsPalpiteB;

        bool acertouA = golsPalpiteA == golsRealA;
        bool acertouB = golsPalpiteB == golsRealB;
        bool acertouUmLado = acertouA || acertouB;

        // =========================
        // CASO: JOGO FOI EMPATE
        // =========================
        if (realEmpate)
        {
            // Acertou empate (mesmo com placar errado)
            if (palpiteEmpate)
                return 5;

            // Acertou gols de um lado
            if (acertouUmLado)
                return 2;

            return 0;
        }

        // =========================
        // CASO: JOGO NÃO FOI EMPATE
        // =========================
        bool acertouVencedor = false;

        if (!palpiteEmpate)
        {
            bool realAVenceu = golsRealA > golsRealB;
            bool palpiteAVenceu = golsPalpiteA > golsPalpiteB;

            acertouVencedor = realAVenceu == palpiteAVenceu;
        }

        // Vencedor + um lado
        if (acertouVencedor && acertouUmLado)
            return 7;

        // Só vencedor
        if (acertouVencedor)
            return 5;

        // Só gols
        if (acertouUmLado)
            return 2;

        return 0;
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
}


