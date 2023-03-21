using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Laps.Commands.CreateLap;

public record CreateLapCommand : IRequest<int>
{
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
}

public class CreateLapCommandHandler : IRequestHandler<CreateLapCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLapCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLapCommand request, CancellationToken cancellationToken)
    {
        var entity = new Lap
        {
            StartTime = request.StartTime,
            TotalElapsedTime = request.TotalElapsedTime,
            TotalTimerTime = request.TotalTimerTime,
            Timestamp = request.Timestamp
        };

        _context.Laps.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}