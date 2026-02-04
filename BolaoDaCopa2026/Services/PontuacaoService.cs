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

        // Empate correto (placar errado)
        if (realEmpate && palpiteEmpate)
            return 5;

        // Vitória correta (ambos NÃO empate)
        if (!realEmpate && !palpiteEmpate)
        {
            bool realAVenceu = golsRealA > golsRealB;
            bool palpiteAVenceu = golsPalpiteA > golsPalpiteB;

            if (realAVenceu == palpiteAVenceu)
                return 7;
        }

        // Errou resultado → pode pontuar só por gols individuais
        int pontos = 0;

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


