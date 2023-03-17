using MediatR;
using RunnerTools.Application.Common.Security;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Commands.PurgeWorkouts;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeWorkoutsCommand : IRequest;

public class PurgeWorkoutsCommandHandler:IRequestHandler<PurgeWorkoutsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeWorkoutsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeWorkoutsCommand request, CancellationToken cancellationToken)
    {
        _context.Workouts.RemoveRange(_context.Workouts);

        await _context.SaveChangesAsync(cancellationToken);
    }
}