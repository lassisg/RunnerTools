﻿using FluentAssertions;
using FluentAssertions.Extensions;
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
    public void ShouldReturnCorrectCadence(decimal speed, int targetCadenceMinutes, int targetCadenceSeconds)
    {
        var expectedCadence = new TimeSpan(0, targetCadenceMinutes, targetCadenceSeconds);
        
        var cadence = speed.ToCadence();

        cadence.Should().Be(expectedCadence);
    }
    
    [Test]
    [TestCase(6, 0, 10)]
    [TestCase(5, 45, 10.43)]
    [TestCase(5, 27, 11)]
    [TestCase(4, 30, 13.33)]
    public void ShouldReturnCorrectSpeed(int cadenceMinutes, int cadenceSeconds, decimal targetSpeed)
    {
        var cadence = new TimeSpan(0, cadenceMinutes, cadenceSeconds);
        
        var speed = cadence.ToSpeed();

        speed.Should().BeApproximately(targetSpeed,0.01M);
    }
    
    [Test]
    [TestCase(10, 0, 50, 0, 5, 0)]
    [TestCase(10, 1, 0, 0, 6, 0)]
    [TestCase(6.01, 0, 27, 55, 4, 38)]
    [TestCase(9.85, 0, 49, 13, 5, 0)]
    [TestCase(42.48, 4, 40, 13, 6, 36)]
    [TestCase(51.21, 8, 33, 04, 10, 01)]
    public void ShouldReturnCorrectTargetCadence(decimal distance, int durationHours, int durationMinutes, int durationSeconds, int targetCadenceMinutes, int targetCadenceSeconds)
    {
        var targetCadence = new TimeSpan(0, targetCadenceMinutes, targetCadenceSeconds);
        var duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);
        
        var cadence = BasicCalculations.GetTargetCadence(distance, duration);

        cadence.Should().BeCloseTo(targetCadence,1.Seconds());
    }
    /* 
     * Cálculo de velocidade (dada uma distância e tempo desejados)
     * Exemplo: 10 km em 50 minutos -> 12 min/km
     */
    /* 
     * Cálculo de tempo (dados ritmo e distância desejados)
     * Exemplo: 21,097 km (meia maratona) com ritmo de 5:30 min/km -> 1:56:02
     */
}