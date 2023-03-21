using MediatR;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Records.Commands.UpdateRecord;

public record UpdateRecordCommand : IRequest<int>
{
    public object Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int Cadence { get; set; }
}
    
public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateRecordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Records
                                   .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Record), request.Id);
        }

        entity.Timestamp = request.Timestamp;
        entity.Cadence = request.Cadence;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}