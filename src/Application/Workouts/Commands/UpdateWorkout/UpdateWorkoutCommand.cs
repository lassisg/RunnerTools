using MediatR;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;
using RunnerTools.Domain.Enums;

namespace RunnerTools.Application.Workouts.Commands.UpdateWorkout;

public record UpdateWorkoutCommand : IRequest
{
    public int Id { get; set; }
    public Sport Sport { get; set; }
    public int NumberOfValidSteps { get; set; }
}

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateWorkoutCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Workouts
                                   .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Workout), request.Id);
        }

        entity.Sport = request.Sport;
        entity.NumberOfValidSteps = request.NumberOfValidSteps;

        await _context.SaveChangesAsync(cancellationToken);
    }
}