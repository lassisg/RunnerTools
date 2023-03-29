using FluentAssertions;
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
        
        var cadence = BasicCalculations.SpeedToCadence(speed);

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
        
        var speed = BasicCalculations.CadenceToSpeed(cadence);

        speed.Should().BeApproximately(targetSpeed,0.05M);
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
    
    [Test]
    [TestCase(10, 0, 50, 0, 12.00)]
    [TestCase(10, 1, 0, 0, 10.00)]
    [TestCase(6.01, 0, 27, 55, 12.9)]
    [TestCase(9.85, 0, 49, 13, 12.00)]
    [TestCase(42.48, 4, 40, 13, 9.10)]
    [TestCase(51.21, 8, 33, 04, 6.00)]
    public void ShouldReturnCorrectTargetSpeed(decimal distance, int durationHours, int durationMinutes, int durationSeconds, decimal targetSpeed)
    {
        var duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);
        
        var speed = BasicCalculations.GetTargetSpeed(distance, duration);

        speed.Should().BeApproximately(targetSpeed, 0.05M);
    }
    
    [Test]
    [TestCase(5, 5, 10, 0, 25, 50)]
    [TestCase(10, 5, 20, 0, 53, 20)]
    [TestCase(21.097, 5, 30, 1, 56, 02)]
    [TestCase(42.195, 6, 00, 4, 13, 10)]
    [TestCase(65.00, 8, 30, 9, 12, 30)]
    public void ShouldReturnCorrectTargetDuration(decimal distance, int cadenceMinutes, int cadenceSeconds, int targetDurationHours, int targetDurationMinutes, int targetDurationSeconds)
    {
        var targetDuration = new TimeSpan(targetDurationHours, targetDurationMinutes, targetDurationSeconds);
        var cadence = new TimeSpan(0, cadenceMinutes, cadenceSeconds);
        
        var duration = BasicCalculations.GetTargetDuration(distance, cadence);

        duration.Should().BeCloseTo(targetDuration, 1.Seconds());
    }
}