using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.WorkoutSteps.Commands.CreateWorkoutStep;
using RunnerTools.Application.WorkoutSteps.Commands.DeleteWorkoutStep;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.IntegrationTests.WorkoutSteps.Commands;

public class DeleteWorkoutStepTests : BaseTestFixture
{
    // [Test]
    // public async Task ShouldRequireValidTodoItemId()
    // {
    //     var command = new DeleteWorkoutStepCommand(99);
    //
    //     await FluentActions.Invoking(() =>
    //         SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    // }
    
    // [Test]
    // public async Task ShouldDeleteWorkout()
    // {
    //     var listId = await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Running,
    //         NumberOfValidSteps = 1
    //     });
    //
    //     var itemId = await SendAsync(new CreateWorkoutStepCommand
    //     {
    //         WorkoutId = 1,
    //         Index = 0
    //     });
    //
    //     await SendAsync(new DeleteWorkoutStepCommand(itemId));
    //
    //     var item = await FindAsync<WorkoutStep>(itemId);
    //
    //     item.Should().BeNull();
    // }
}
