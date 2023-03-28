using Dynastream.Fit;
using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;
using Sport = RunnerTools.Domain.Enums.Sport;

namespace RunnerTools.Application.Workouts.Commands.CreateWorkout;

public record CreateWorkoutCommand : IRequest<int>
{
    public string Name { get; set; }
    public Sport Sport { get; set; }
    public int NumberOfValidSteps { get; set; }
}

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWorkoutCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var entity = new Workout();

        entity.Sport = request.Sport;
        entity.NumberOfValidSteps = request.NumberOfValidSteps;

        _context.Workouts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}