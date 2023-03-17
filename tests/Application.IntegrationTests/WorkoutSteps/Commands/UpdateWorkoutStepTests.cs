using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Application.WorkoutSteps.Commands.CreateWorkoutStep;
using RunnerTools.Application.WorkoutSteps.Commands.UpdateWorkoutStep;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.IntegrationTests.WorkoutSteps.Commands;

using static Testing;

public class UpdateWorkoutStepTests : BaseTestFixture
{
    // [Test]
    // public async Task ShouldRequireValidWorkoutStepId()
    // {
    //     var command = new UpdateWorkoutStepCommand { Id = 99, Index = 99 };
    //     await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    // }
    
    // [Test]
    // public async Task ShouldUpdateWorkoutStep()
    // {
    //     var userId = await RunAsDefaultUserAsync();
    //
    //     var listId = await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Running,
    //         NumberOfValidSteps = 7
    //     });
    //
    //     var workoutStepId = await SendAsync(new CreateWorkoutStepCommand
    //     {
    //         WorkoutId = 1,
    //         Index = 0
    //     });
    //
    //     var command = new UpdateWorkoutStepCommand
    //     {
    //         Id = workoutStepId,
    //         WorkoutId = 2
    //     };
    //
    //     await SendAsync(command);
    //
    //     var item = await FindAsync<WorkoutStep>(workoutStepId);
    //
    //     item.Should().NotBeNull();
    //     item!.WorkoutId.Should().Be(command.WorkoutId);
    //     item.LastModifiedBy.Should().NotBeNull();
    //     item.LastModifiedBy.Should().Be(userId);
    //     item.LastModified.Should().NotBeNull();
    //     item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    // }
}
