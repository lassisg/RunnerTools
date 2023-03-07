using RunnerTools.Application.TodoLists.Queries.ExportTodos;

namespace RunnerTools.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
