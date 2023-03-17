using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.WorkoutSteps.Commands.DeleteWorkoutStep;

public record DeleteWorkoutStepCommand(int Id) : IRequest;

public class DeleteWorkoutStepCommandHandler : IRequestHandler<DeleteWorkoutStepCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkoutStepCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteWorkoutStepCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkoutSteps
                                   .Where(s => s.Id == request.Id)
                                   .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkoutStep), request.Id);
        }

        _context.WorkoutSteps.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}