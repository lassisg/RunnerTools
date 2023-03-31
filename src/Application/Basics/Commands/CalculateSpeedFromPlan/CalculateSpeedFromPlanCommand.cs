using MediatR;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateSpeedFromPlan;


public record CalculateSpeedFromPlanCommand(decimal distance, TimeSpan duration) : IRequest<SpeedFromPlanVm>;

public class CalculateSpeedFromPlanCommandHandler : IRequestHandler<CalculateSpeedFromPlanCommand, SpeedFromPlanVm>
{
    public Task<SpeedFromPlanVm> Handle(CalculateSpeedFromPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new SpeedFromPlanVm()
        {
            Distance = request.distance,
            Duration = request.duration,
            Speed = RunningSpeed.FromPlan(request.distance, request.duration)
        };

        return Task.FromResult(entity);
    }
}