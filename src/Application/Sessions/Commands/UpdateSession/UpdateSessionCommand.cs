using MediatR;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Sessions.Commands.UpdateSession;

public record UpdateSessionCommand : IRequest<int>
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
}

public class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateSessionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Sessions
                                   .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Session), request.Id);
        }

        entity.StartTime = request.StartTime;
        entity.TotalElapsedTime = request.TotalElapsedTime;
        entity.TotalTimerTime = request.TotalTimerTime;
        entity.Timestamp = request.Timestamp;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}