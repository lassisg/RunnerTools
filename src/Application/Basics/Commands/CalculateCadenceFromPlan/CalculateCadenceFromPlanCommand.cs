using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;


public record CalculateCadenceFromPlanCommand(decimal distance, TimeSpan duration) : IRequest<RunningDurationDto>;

public class CalculateCadenceFromPlanCommandHandler : IRequestHandler<CalculateCadenceFromPlanCommand, RunningDurationDto>
{
    public Task<RunningDurationDto> Handle(CalculateCadenceFromPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new RunningDurationDto()
        {
            Distance = request.distance,
            Duration = request.duration,
            Cadence = RunningCadence.FromPlan(request.distance, request.duration) 
        };

        return Task.FromResult(entity);
    }
}