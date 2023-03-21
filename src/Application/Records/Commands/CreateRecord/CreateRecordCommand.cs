using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Records.Commands.CreateRecord;

public record CreateRecordCommand : IRequest<int>
{
    public DateTime Timestamp { get; set; }
    public int Cadence { get; set; }
}

public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRecordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = new Record
        {
            Timestamp = request.Timestamp,
            Cadence = request.Cadence
        };

        _context.Records.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}