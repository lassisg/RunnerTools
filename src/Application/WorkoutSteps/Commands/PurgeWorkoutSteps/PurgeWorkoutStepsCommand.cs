using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Security;

namespace RunnerTools.Application.WorkoutSteps.Commands.PurgeWorkoutSteps;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeWorkoutStepsCommand : IRequest
{
    public int WorkoutId { get; set; }
}

public class PurgeWorkoutStepsCommandHandler : IRequestHandler<PurgeWorkoutStepsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeWorkoutStepsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeWorkoutStepsCommand request, CancellationToken cancellationToken)
    {
        _context.WorkoutSteps
                .RemoveRange(_context.WorkoutSteps
                                     .Where(s=>s.WorkoutId == request.WorkoutId));

        await _context.SaveChangesAsync(cancellationToken);
    }
}