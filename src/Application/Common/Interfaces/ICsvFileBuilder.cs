using RunnerTools.Application.TodoLists.Queries.ExportTodos;
using RunnerTools.Application.Workouts.Queries.ExportWorkouts;

namespace RunnerTools.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    byte[] BuildWorkoutFile(IEnumerable<WorkoutRecord> records);
}
