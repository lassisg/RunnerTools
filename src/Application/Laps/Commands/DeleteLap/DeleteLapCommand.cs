using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Laps.Commands.DeleteLap;

public record DeleteLapCommand(int Id) : IRequest;

public class DeleteLapCommandHandler : IRequestHandler<DeleteLapCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteLapCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteLapCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Laps
                                   .Where(l => l.Id == request.Id)
                                   .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Lap), request.Id);
        }

        _context.Laps.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}