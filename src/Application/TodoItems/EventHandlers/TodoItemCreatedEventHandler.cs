using RunnerTools.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace RunnerTools.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("RunnerTools Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
