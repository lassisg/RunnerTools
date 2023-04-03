using MediatR;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;


public record CalculateCadenceFromPlanCommand(decimal distance, TimeSpan duration) : IRequest<RunningDurationVm>;

public class CalculateCadenceFromPlanCommandHandler : IRequestHandler<CalculateCadenceFromPlanCommand, RunningDurationVm>
{
    public Task<RunningDurationVm> Handle(CalculateCadenceFromPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new RunningDurationVm()
        {
            Distance = request.distance,
            Duration = request.duration,
            Cadence = RunningCadence.FromPlan(request.distance, request.duration) 
        };

        return Task.FromResult(entity);
    }
}