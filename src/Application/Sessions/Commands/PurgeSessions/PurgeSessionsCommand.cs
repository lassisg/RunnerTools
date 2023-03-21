using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Security;

namespace RunnerTools.Application.Sessions.Commands.PurgeSessions;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeSessionsCommand : IRequest;

public class PurgeSessionsCommandHandler : IRequestHandler<PurgeSessionsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeSessionsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeSessionsCommand request, CancellationToken cancellationToken)
    {
        _context.Sessions.RemoveRange(_context.Sessions);

        await _context.SaveChangesAsync(cancellationToken);
    }
}