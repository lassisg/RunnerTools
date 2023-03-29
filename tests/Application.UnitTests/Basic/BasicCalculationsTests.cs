using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Basic;

namespace RunnerTools.Application.UnitTests.Basic;

[TestFixture]
public class BasicCalculationsTests
{
    [Test]
    [TestCase(10, 6, 0)]
    [TestCase(10.43, 5, 45)]
    [TestCase(11, 5, 27)]
    [TestCase(13.33, 4, 30)]
    public void ShouldReturnCorrectCadence(decimal speed, int minutes, int seconds)
    {
        var cadence = new TimeSpan(0, minutes, seconds);
        var result = speed.ToCadence();

        result.Should().Be(cadence);
    }
    
    [Test]
    [TestCase(6, 0, 10)]
    [TestCase(5, 45, 10.43)]
    [TestCase(5, 27, 11)]
    [TestCase(4, 30, 13.33)]
    public void ShouldReturnCorrectSpeed(int minutes, int seconds, decimal speed)
    {
        var cadence = new TimeSpan(0, minutes, seconds);
        var result = cadence.ToSpeed();

        result.Should().BeApproximately(speed,0.01M);
    }
    /* 
     * Cálculo de ritmo (dada distância e tempo desejados)
     * Exemplo: 10 km em 50 minutos -> 5 min/km
     */ 
    /* 
     * Cálculo de velocidade (dada uma distância e tempo desejados)
     * Exemplo: 10 km em 50 minutos -> 12 min/km
     */
    /* 
     * Cálculo de tempo (dados ritmo e distância desejados)
     * Exemplo: 21,097 km (meia maratona) com ritmo de 5:30 min/km -> 1:56:02
     */
}