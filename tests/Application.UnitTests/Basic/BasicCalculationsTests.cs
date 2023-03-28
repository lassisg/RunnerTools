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
}