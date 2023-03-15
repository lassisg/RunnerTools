using RunnerTools.Domain.Entities;

namespace RunnerTools.Infrastructure.Persistence.Seeds;

public static class WorkoutStepSeeder
{
    public static IList<WorkoutStep> Seed(int steps)
    {
        var workoutSteps = new List<WorkoutStep>();
        for (int i = 0; i < steps; i++)
        {
            workoutSteps.Add(new WorkoutStep() {Index = i});
        }
        
        return workoutSteps;
    }
}