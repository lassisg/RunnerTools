using FluentAssertions;
using NUnit.Framework;
using RunnerTools.Application.Workouts.Queries.GetWorkouts;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;
using RunnerTools.Domain.ValueObjects;

namespace RunnerTools.Application.IntegrationTests.Workouts.Queries;

using static Testing;

public class GetWorkoutsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnWorkouts()
    {
        await RunAsDefaultUserAsync();

        var query = new GetWorkoutQuery();

        var result = await SendAsync(query);

        result.Workouts.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllWorkoutStepsAndItems()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Workout
        {
            Sport = Sport.Running,
            NumberOfValidSteps = 5,
            WorkoutSteps =
                    {
                        new WorkoutStep
                        {
                            WorkoutId = 1, 
                            Index = 0, 
                            DurationType = StepDuration.Distance,
                            Duration = 1,
                            TargetType = StepTarget.HeartRate,
                            TargetValue = 100,
                            TargetLow = 80,
                            TargetHigh = 120
                        },
                        new WorkoutStep { 
                            WorkoutId = 1, 
                            Index = 1, 
                            DurationType = StepDuration.Distance,
                            Duration = 1,
                            TargetType = StepTarget.HeartRate,
                            TargetValue = 100,
                            TargetLow = 80,
                            TargetHigh = 120
                        },
                        new WorkoutStep { 
                            WorkoutId = 1, 
                            Index = 2, 
                            DurationType = StepDuration.Distance,
                            Duration = 1,
                            TargetType = StepTarget.HeartRate,
                            TargetValue = 100,
                            TargetLow = 80,
                            TargetHigh = 120
                        },
                        new WorkoutStep { 
                            WorkoutId = 1, 
                            Index = 3, 
                            DurationType = StepDuration.Distance,
                            Duration = 1,
                            TargetType = StepTarget.HeartRate,
                            TargetValue = 100,
                            TargetLow = 80,
                            TargetHigh = 120
                        },
                        new WorkoutStep { 
                            WorkoutId = 1, 
                            Index = 4, 
                            DurationType = StepDuration.Distance,
                            Duration = 1,
                            TargetType = StepTarget.HeartRate,
                            TargetValue = 100,
                            TargetLow = 80,
                            TargetHigh = 120
                        }
                    }
        });

        var query = new GetWorkoutQuery();

        var result = await SendAsync(query);

        result.Workouts.Should().HaveCount(1);
        result.Workouts.First().WorkoutSteps.Should().HaveCount(7);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetWorkoutQuery();

        var action = () => SendAsync(query);
        
        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
