using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Sessions.Commands.CreateSession;

public record CreateSessionCommand : IRequest<int>
{
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
}

public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSessionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Session
        {
            StartTime = request.StartTime,
            TotalElapsedTime = request.TotalElapsedTime,
            TotalTimerTime = request.TotalTimerTime,
            Timestamp = request.Timestamp
        };

        _context.Sessions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}