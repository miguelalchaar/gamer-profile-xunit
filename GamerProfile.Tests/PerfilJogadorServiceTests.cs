using GamerProfile.App;

namespace GamerProfile.Tests;

public class PerfilJogadorServiceTests
{
    private readonly PerfilJogadorService _service = new();

    [Fact]
    public void GerarTagUsuario_DeveConcatenarNicknameECodigoComHashtag()
    {
        var resultado = _service.GerarTagUsuario("Nickname", "0000");

        Assert.Equal("Nickname#0000", resultado);
    }

    [Fact]
    public void CalcularXPTotal_DeveSomarFasesEAplicarBonusDe100()
    {
        var resultado = _service.CalcularXPTotal(200, 300);

        Assert.Equal(600, resultado);
    }

    [Fact]
    public void EEligivelParaRanked_DeveValidarNivelMinimoDe15()
    {
        Assert.True(_service.EEligivelParaRanked(15));
        Assert.True(_service.EEligivelParaRanked(20));
        Assert.False(_service.EEligivelParaRanked(14));
        Assert.False(_service.EEligivelParaRanked(0));
    }
}