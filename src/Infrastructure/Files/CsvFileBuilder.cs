using System.Globalization;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.TodoLists.Queries.ExportTodos;
using RunnerTools.Infrastructure.Files.Maps;
using CsvHelper;
using RunnerTools.Application.Workouts.Queries.ExportWorkouts;

namespace RunnerTools.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }

    public byte[] BuildWorkoutFile(IEnumerable<WorkoutRecord> records)
    {
        throw new NotImplementedException();
    }
}
