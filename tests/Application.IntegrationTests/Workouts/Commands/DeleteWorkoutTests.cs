using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Application.Workouts.Commands.DeleteWorkout;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.IntegrationTests.Workouts.Commands;

using static Testing;

public class DeleteWorkoutTests : BaseTestFixture
{
    // [Test]
    // public async Task ShouldRequireValidWorkoutId()
    // {
    //     var command = new DeleteWorkoutCommand(99);
    //     await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    // }
    //
    // [Test]
    // public async Task ShouldDeleteWorkout()
    // {
    //     var workoutId = await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Running,
    //         NumberOfValidSteps = 7
    //     });
    //
    //     await SendAsync(new DeleteWorkoutCommand(workoutId));
    //
    //     var workout = await FindAsync<Workout>(workoutId);
    //
    //     workout.Should().BeNull();
    // }
}
