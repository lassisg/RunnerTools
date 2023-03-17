using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Workouts.Queries.ExportWorkouts;

namespace RunnerTools.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildWorkoutFile(IEnumerable<WorkoutRecord> records)
    {
        throw new NotImplementedException();
    }
}
