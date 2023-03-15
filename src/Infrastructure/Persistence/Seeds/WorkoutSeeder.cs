using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Infrastructure.Persistence.Seeds;

public static class WorkoutSeeder
{
    public static Workout Seed()
    {
        const int steps = 7;
        return new Workout()
        {
            Sport = Sport.Running,
            NumberOfValidSteps = steps,
            Name = "Regenerative",
            WorkoutSteps = 
            {
                new WorkoutStep {Index = 0},
                new WorkoutStep {Index = 1},
                new WorkoutStep {Index = 2},
                new WorkoutStep {Index = 3},
                new WorkoutStep {Index = 4},
                new WorkoutStep {Index = 5},
                new WorkoutStep {Index = 6},
            }
        };
    }
}