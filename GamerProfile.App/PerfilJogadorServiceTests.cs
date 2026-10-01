namespace GamerProfile.App;

public class PerfilJogadorService
{
    public string GerarTagUsuario(string nickname, string codigo)
    {
        return $"{nickname}#{codigo}";
    }

    public int CalcularXPTotal(int xpFase1, int xpFase2)
    {
        const int bonusFixo = 100;
        return xpFase1 + xpFase2 + bonusFixo;
    }

    public bool EEligivelParaRanked(int nivelJogador)
    {
        return nivelJogador >= 15;
    }
}