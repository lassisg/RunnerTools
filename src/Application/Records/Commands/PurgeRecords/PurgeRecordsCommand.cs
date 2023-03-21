using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Security;

namespace RunnerTools.Application.Records.Commands.PurgeRecords;


[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeRecordsCommand : IRequest;

public class PurgeRecordsCommandHandler : IRequestHandler<PurgeRecordsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeRecordsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeRecordsCommand request, CancellationToken cancellationToken)
    {
        _context.Records.RemoveRange(_context.Records);

        await _context.SaveChangesAsync(cancellationToken);
    }
}