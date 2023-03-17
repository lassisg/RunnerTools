using RunnerTools.Application.Workouts.Queries.ExportWorkouts;

namespace RunnerTools.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildWorkoutFile(IEnumerable<WorkoutRecord> records);
}
