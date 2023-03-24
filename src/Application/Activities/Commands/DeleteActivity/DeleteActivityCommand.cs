using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Activities.Queries.GetActivities;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;
using Activity = Dynastream.Fit.Activity;

namespace RunnerTools.Application.Activities.Commands.DeleteActivity;

public record DeleteActivityCommand(int Id) : IRequest;

public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Activities
                                   .SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Activity), request.Id);

        _context.Activities.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}