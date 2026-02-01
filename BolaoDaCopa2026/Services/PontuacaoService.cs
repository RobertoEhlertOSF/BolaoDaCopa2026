using BolaoDaCopa2026.Models;

public class PontuacaoService
{
    public int CalcularPontuacaoApostador(
       int golsRealA,
       int golsRealB,
       int golsPalpiteA,
       int golsPalpiteB)
    {
        if (golsPalpiteA == golsRealA && golsPalpiteB == golsRealB)
            return 10;

        if (golsRealA == golsRealB && golsPalpiteA == golsPalpiteB)
            return 5;

        if ((golsRealA > golsRealB && golsPalpiteA > golsPalpiteB) ||
            (golsRealA < golsRealB && golsPalpiteA < golsPalpiteB))
            return 7;

        if ((golsRealA == golsRealB && golsPalpiteA != golsPalpiteB) ||
            (golsRealA != golsRealB && golsPalpiteA == golsPalpiteB) ||
            (golsPalpiteA == golsRealA || golsPalpiteB == golsRealB))
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


