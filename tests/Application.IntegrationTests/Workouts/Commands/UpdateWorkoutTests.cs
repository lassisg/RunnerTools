using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Application.Workouts.Commands.UpdateWorkout;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.IntegrationTests.Workouts.Commands;

public class UpdateWorkoutTests : BaseTestFixture
{
    // [Test]
    // public async Task ShouldRequireValidWorkoutId()
    // {
    //     var command = new UpdateWorkoutCommand { Id = 99, Sport = Sport.Running, NumberOfValidSteps = 4};
    //     await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    // }
    
    // [Test]
    // public async Task ShouldUpdateWorkout()
    // {
    //     var userId = await RunAsDefaultUserAsync();
    //
    //     var workoutId = await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Running,
    //         NumberOfValidSteps = 7
    //     });
    //
    //     var command = new UpdateWorkoutCommand
    //     {
    //         Id = workoutId,
    //         Sport = Sport.Training,
    //         NumberOfValidSteps = 5
    //     };
    //
    //     await SendAsync(command);
    //
    //     var list = await FindAsync<Workout>(workoutId);
    //
    //     list.Should().NotBeNull();
    //     list!.Title.Should().Be(command.Title);
    //     list.LastModifiedBy.Should().NotBeNull();
    //     list.LastModifiedBy.Should().Be(userId);
    //     list.LastModified.Should().NotBeNull();
    //     list.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    // }
}
