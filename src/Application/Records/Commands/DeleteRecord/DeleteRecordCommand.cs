using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Records.Commands.DeleteRecord;

public record DeleteRecordCommand(int Id) : IRequest;

public class DeleteRecordCommandHandler : IRequestHandler<DeleteRecordCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRecordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Records
                                   .Where(r => r.Id == request.Id)
                                   .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Record), request.Id);
        }

        _context.Records.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}