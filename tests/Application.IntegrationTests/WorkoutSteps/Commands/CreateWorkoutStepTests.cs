using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Application.WorkoutSteps.Commands.CreateWorkoutStep;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.IntegrationTests.WorkoutSteps.Commands;

using static Testing;

public class CreateWorkoutStepTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateWorkoutCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateWorkoutStep()
    {
        var userId = await RunAsDefaultUserAsync();

        var workoutStepId = await SendAsync(new CreateWorkoutStepCommand
        {
            WorkoutId = 1,
            Index = 0
        });

        var command = new CreateWorkoutStepCommand
        {
            WorkoutId = 1,
            Index = 0
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<WorkoutStep>(itemId);

        item.Should().NotBeNull();
        item!.WorkoutId.Should().Be(command.WorkoutId);
        item.Index.Should().Be(command.Index);
        item.CreatedBy.Should().Be(userId);
        item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        item.LastModifiedBy.Should().Be(userId);
        item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
