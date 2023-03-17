using MediatR;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.WorkoutSteps.Commands.UpdateWorkoutStep;

public record UpdateWorkoutStepCommand : IRequest
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public int Index { get; set; }
}

public class UpdateWorkoutStepCommandHandler : IRequestHandler<UpdateWorkoutStepCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateWorkoutStepCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateWorkoutStepCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkoutSteps
                                   .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(WorkoutStep), request.WorkoutId);
        }

        entity.WorkoutId = request.WorkoutId;
        entity.Index = request.Index;

        await _context.SaveChangesAsync(cancellationToken);
    }
}