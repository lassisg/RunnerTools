using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateSpeedFromPlan;


public record CalculateSpeedFromPlanCommand(decimal distance, TimeSpan duration) : IRequest<RunningDurationDto>;

public class CalculateSpeedFromPlanCommandHandler : IRequestHandler<CalculateSpeedFromPlanCommand, RunningDurationDto>
{
    public Task<RunningDurationDto> Handle(CalculateSpeedFromPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = new RunningDurationDto()
        {
            Distance = request.distance,
            Duration = request.duration,
            Speed = RunningSpeed.FromPlan(request.distance, request.duration)
        };

        return Task.FromResult(entity);
    }
}