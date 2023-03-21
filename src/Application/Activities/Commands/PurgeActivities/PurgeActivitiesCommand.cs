using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Security;

namespace RunnerTools.Application.Activities.Commands.PurgeActivities;


[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeActivitiesCommand : IRequest;

public class PurgeActivitiesCommandHandler : IRequestHandler<PurgeActivitiesCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeActivitiesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeActivitiesCommand request, CancellationToken cancellationToken)
    {
        _context.Activities.RemoveRange(_context.Activities);

        await _context.SaveChangesAsync(cancellationToken);
    }
}