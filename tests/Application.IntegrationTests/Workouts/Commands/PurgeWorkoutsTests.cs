using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Security;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;
using RunnerTools.Application.Workouts.Commands.PurgeWorkouts;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.IntegrationTests.Workouts.Commands;

public class PurgeWorkoutsTests : BaseTestFixture
{
    // [Test]
    // public async Task ShouldDenyAnonymousUser()
    // {
    //     var command = new PurgeWorkoutsCommand();
    //
    //     command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();
    //
    //     var action = () => SendAsync(command);
    //
    //     await action.Should().ThrowAsync<UnauthorizedAccessException>();
    // }
    
    // [Test]
    // public async Task ShouldDenyNonAdministrator()
    // {
    //     await RunAsDefaultUserAsync();
    //
    //     var command = new PurgeWorkoutsCommand();
    //
    //     var action = () => SendAsync(command);
    //
    //     await action.Should().ThrowAsync<ForbiddenAccessException>();
    // }
    
    // [Test]
    // public async Task ShouldAllowAdministrator()
    // {
    //     await RunAsAdministratorAsync();
    //
    //     var command = new PurgeWorkoutsCommand();
    //
    //     var action = () => SendAsync(command);
    //
    //     await action.Should().NotThrowAsync<ForbiddenAccessException>();
    // }
    
    // [Test]
    // public async Task ShouldDeleteAllWorkouts()
    // {
    //     await RunAsAdministratorAsync();
    //
    //     await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Running,
    //         NumberOfValidSteps = 7
    //     });
    //
    //     await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Training,
    //         NumberOfValidSteps = 3
    //     });
    //
    //     await SendAsync(new CreateWorkoutCommand
    //     {
    //         Sport = Sport.Walking,
    //         NumberOfValidSteps = 1
    //     });
    //
    //     await SendAsync(new PurgeWorkoutsCommand());
    //
    //     var count = await CountAsync<TodoList>();
    //
    //     count.Should().Be(0);
    // }
}
