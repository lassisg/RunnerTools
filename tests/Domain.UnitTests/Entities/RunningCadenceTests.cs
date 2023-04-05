using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Extensions;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Domain.UnitTests.Entities;

[TestFixture]
public class RunningCadenceTests
{
    [Test]
    [TestCase(10, 6, 0)]
    [TestCase(10.43, 5, 45)]
    [TestCase(11, 5, 27)]
    [TestCase(13.33, 4, 30)]
    public void ShouldReturnCorrectCadence(decimal speed,
                                           int targetCadenceMinutes, int targetCadenceSeconds)
    {
        var expectedCadence = new TimeSpan(0, targetCadenceMinutes, targetCadenceSeconds);

        // var cadence = BasicCalculations.SpeedToCadence(speed);
        var cadence = RunningCadence.FromSpeed(speed);

        cadence.Should().Be(expectedCadence);
    }
    
    [Test]
    [TestCase(10, 0, 50, 0, 5, 0)]
    [TestCase(10, 1, 0, 0, 6, 0)]
    [TestCase(6.01, 0, 27, 55, 4, 38)]
    [TestCase(9.85, 0, 49, 13, 5, 0)]
    [TestCase(42.48, 4, 40, 13, 6, 36)]
    [TestCase(51.21, 8, 33, 04, 10, 01)]
    public void ShouldReturnCorrectCadenceFromPlan(decimal distance, 
                                                   int durationHours, int durationMinutes,int durationSeconds,
                                                   int targetCadenceMinutes, int targetCadenceSeconds)
    {
        var targetCadence = new TimeSpan(0, targetCadenceMinutes, targetCadenceSeconds);
        var duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);

        var cadence = RunningCadence.FromPlan(distance, duration);

        cadence.Should().BeCloseTo(targetCadence, 1.Seconds());
    }
    
    [Test]
    [TestCase(1.99)]
    [TestCase(30.01)]
    public void ShouldThrowInvalidSpeedException(decimal speed)
    {
        Action act = () => RunningCadence.FromSpeed(speed);

        act.Should().Throw<InvalidSpeedException>()
           .WithMessage($"Invalid speed '{speed}'.");
    }
}