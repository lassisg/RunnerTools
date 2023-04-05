using NUnit.Framework;
using FluentAssertions;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Domain.UnitTests.Entities;

[TestFixture]
public class RunningSpeedTests
{
    [Test]
    [TestCase(6, 0, 10)]
    [TestCase(5, 45, 10.43)]
    [TestCase(5, 27, 11)]
    [TestCase(4, 30, 13.33)]
    public void ShouldReturnCorrectSpeed(int cadenceMinutes, int cadenceSeconds,
                                         decimal targetSpeed)
    {
        var cadence = new TimeSpan(0, cadenceMinutes, cadenceSeconds);

        var speed = RunningSpeed.FromCadence(cadence);

        speed.Should().BeApproximately(targetSpeed, 0.05M);
    }

    [Test]
    [TestCase(10, 0, 50, 0, 12.00)]
    [TestCase(10, 1, 0, 0, 10.00)]
    [TestCase(6.01, 0, 27, 55, 12.9)]
    [TestCase(9.85, 0, 49, 13, 12.00)]
    [TestCase(42.48, 4, 40, 13, 9.10)]
    [TestCase(51.21, 8, 33, 04, 6.00)]
    public void ShouldReturnCorrectSpeedFromPlan(decimal distance,
                                                 int durationHours, int durationMinutes, int durationSeconds,
                                                 decimal targetSpeed)
    {
        var duration = new TimeSpan(durationHours, durationMinutes, durationSeconds);

        var speed = RunningSpeed.FromPlan(distance, duration);

        speed.Should().BeApproximately(targetSpeed, 0.05M);
    }
    
    [Test]
    [TestCase(1, 59)]
    [TestCase(30, 01)]
    public void ShouldThrowInvalidCadenceException(int cadenceMinutes, int cadenceSeconds)
    {
        var cadence = new TimeSpan(0, cadenceMinutes, cadenceSeconds);
        Action act = () => RunningSpeed.FromCadence(cadence);

        act.Should().Throw<InvalidCadenceException>()
           .WithMessage($"Invalid cadence '{cadence.Minutes}:{cadence.Seconds}'.");
    }
}