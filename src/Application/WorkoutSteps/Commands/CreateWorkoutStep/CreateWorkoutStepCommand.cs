using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.WorkoutSteps.Commands.CreateWorkoutStep;

public record CreateWorkoutStepCommand : IRequest<int>
{
    public int WorkoutId { get; set; }
    public int Index { get; set; }
}

public class CreateWorkoutStepCommandHandler : IRequestHandler<CreateWorkoutStepCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWorkoutStepCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWorkoutStepCommand request, CancellationToken cancellationToken)
    {
        var entity = new WorkoutStep
        {
            WorkoutId = request.WorkoutId, 
            Index = request.Index
        };

        _context.WorkoutSteps.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}