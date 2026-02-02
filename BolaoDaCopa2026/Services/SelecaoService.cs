using BolaoDaCopa2026.Data;
using BolaoDaCopa2026.Models;

public class SelecaoService
{
    private readonly BolaoContext _context;

    public SelecaoService(BolaoContext context)
    {
        _context = context;
    }

    public void AtualizarClassificacao(Jogo jogo)
    {
        if (jogo.ClassificacaoProcessada)
            return;

        var a = jogo.SelecaoA;
        var b = jogo.SelecaoB;

        a.Jogos++;
        b.Jogos++;

        a.GolsPro += jogo.GolsSelecaoA.Value;
        a.GolsContra += jogo.GolsSelecaoB.Value;

        b.GolsPro += jogo.GolsSelecaoB.Value;
        b.GolsContra += jogo.GolsSelecaoA.Value;

        if (jogo.GolsSelecaoA > jogo.GolsSelecaoB)
            a.Pontos += 3;
        else if (jogo.GolsSelecaoA < jogo.GolsSelecaoB)
            b.Pontos += 3;
        else
        {
            a.Pontos += 1;
            b.Pontos += 1;
        }

        jogo.ClassificacaoProcessada = true;
        _context.SaveChanges();
    }
}
