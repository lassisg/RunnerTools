using MediatR;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;


public record CalculateCadenceFromPlanCommand(decimal distance, TimeSpan duration) : IRequest<CadenceFromPlanVm>;

public class CalculateCadenceFromPlanCommandHandler : IRequestHandler<CalculateCadenceFromPlanCommand, CadenceFromPlanVm>
{
    public Task<CadenceFromPlanVm> Handle(CalculateCadenceFromPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new CadenceFromPlanVm()
        {
            Distance = request.distance,
            Duration = request.duration,
            Cadence = RunningCadence.FromPlan(request.distance, request.duration) 
        };

        return Task.FromResult(entity);
    }
}