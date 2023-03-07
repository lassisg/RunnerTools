using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
