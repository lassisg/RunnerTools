using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.IntegrationTests.Workouts.Commands;

using static Testing;

public class CreateWorkoutTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateWorkoutCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateWorkout()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateWorkoutCommand
        {
            Sport = Sport.Running,
            NumberOfValidSteps = 7
        };

        var id = await SendAsync(command);

        var workout = await FindAsync<Workout>(id);

        workout.Should().NotBeNull();
        workout!.Sport.Should().Be(command.Sport);
        workout.NumberOfValidSteps.Should().Be(command.NumberOfValidSteps);
        workout.CreatedBy.Should().Be(userId);
        workout.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
