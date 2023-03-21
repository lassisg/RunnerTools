using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Sessions.Commands.DeleteSession;

public record DeleteSessionCommand(int Id) : IRequest;

public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSessionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Sessions
                                   .Where(s => s.Id == request.Id)
                                   .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Session), request.Id);
        }

        _context.Sessions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}