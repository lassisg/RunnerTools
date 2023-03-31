using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Extensions;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Domain.UnitTests.Entities;

[TestFixture]
public class RunningDurationTests
{
    [Test]
    [TestCase(10, 5, 0, 0, 50, 0)]
    [TestCase(10, 6, 0, 1, 0, 0)]
    [TestCase(6.01, 4, 38, 0, 27, 55)]
    [TestCase(9.85, 5, 0, 0, 49, 13)]
    [TestCase(42.48, 6, 36, 4, 40, 13)]
    [TestCase(51.21, 10, 01, 8, 33, 04)]
    public void ShouldReturnCorrectTargetDurationFromCadence(decimal distance, 
                                                             int cadenceMinutes, int cadenceSeconds,
                                                             int targetDurationHours, int targetDurationMinutes, int targetDurationSeconds)
    {
        var targetDuration = new TimeSpan(targetDurationHours, targetDurationMinutes, targetDurationSeconds);
        var cadence = new TimeSpan(0, cadenceMinutes, cadenceSeconds);

        var duration = RunningDuration.FromCadence(distance, cadence);

        duration.Should().BeCloseTo(targetDuration, 10.Seconds());
    }

    [Test]
    [TestCase(5, 11.61, 0, 25, 50)]
    [TestCase(10, 11.25, 0, 53, 20)]
    [TestCase(21.097, 10.91, 1, 56, 02)]
    [TestCase(42.195, 10.00, 4, 13, 10)]
    [TestCase(65.00, 7.06, 9, 12, 30)]
    public void ShouldReturnCorrectTargetDurationFromSpeed(decimal distance, 
                                                           decimal speed,
                                                           int targetDurationHours, int targetDurationMinutes, int targetDurationSeconds)
    {
        var targetDuration = new TimeSpan(targetDurationHours, targetDurationMinutes, targetDurationSeconds);

        var duration = RunningDuration.FromSpeed(distance, speed);

        duration.Should().BeCloseTo(targetDuration, 10.Seconds());
    }
}