using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Security;

namespace RunnerTools.Application.Laps.Commands.PurgeLaps;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeLapsCommand : IRequest;

public class PurgeLapsCommandHandler : IRequestHandler<PurgeLapsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeLapsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeLapsCommand request, CancellationToken cancellationToken)
    {
        _context.Laps.RemoveRange(_context.Laps);

        await _context.SaveChangesAsync(cancellationToken);
    }
}