using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Workouts.Commands.DeleteWorkout;

public record DeleteWorkoutCommand(int Id) : IRequest;

public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkoutCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Workouts
                                   .Where(w => w.Id == request.Id)
                                   .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Workout), request.Id);
        }

        _context.Workouts.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}