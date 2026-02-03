using BolaoDaCopa2026.Models;

public class PontuacaoService
{
    public int CalcularPontuacaoApostador(int golsRealA, int golsRealB, int golsPalpiteA, int golsPalpiteB)
    {
        // Placar exato → 10 pontos
        if (golsPalpiteA == golsRealA && golsPalpiteB == golsRealB)
            return 10;

        int pontos = 0;

        // Acerto do vencedor
        if ((golsRealA > golsRealB && golsPalpiteA > golsPalpiteB) ||  // vitória correta da A
            (golsRealA < golsRealB && golsPalpiteA < golsPalpiteB) ||  // vitória correta da B
            (golsRealA == golsRealB && golsPalpiteA == golsPalpiteB))  // empate correto
        {
            pontos += 7;
        }

        // Acerto de gols individuais
        if (golsPalpiteA == golsRealA)
            pontos += 2;
        if (golsPalpiteB == golsRealB)
            pontos += 2;

        return pontos;
    }

    public int CalcularPontuacaoApostadorMataMata(
        int golsRealA,
        int golsRealB,
        int golsPalpiteA,
        int golsPalpiteB,
        int? vencedorRealId,
        int? vencedorPalpiteId)
    {
        if (golsPalpiteA == golsRealA && golsPalpiteB == golsRealB)
            return 10;

        int pontos = 0;

        if (vencedorRealId.HasValue && vencedorPalpiteId == vencedorRealId)
            pontos += 7;

        if (golsPalpiteA == golsRealA)
            pontos += 2;
        if (golsPalpiteB == golsRealB)
            pontos += 2;

        return pontos;
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

