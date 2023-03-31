using MediatR;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateDurationFromSpeed;

public record CalculateDurationFromSpeedCommand(decimal distance, decimal speed) : IRequest<DurationFromSpeedVm>;

public class CalculateDurationFromSpeedCommandHandler : IRequestHandler<CalculateDurationFromSpeedCommand, DurationFromSpeedVm>
{
    public Task<DurationFromSpeedVm> Handle(CalculateDurationFromSpeedCommand request, CancellationToken cancellationToken)
    {
        var entity = new DurationFromSpeedVm()
        {
            Distance = request.distance, 
            Speed = request.speed, 
            Duration = RunningDuration.FromSpeed(request.distance, request.speed)
        };

        return Task.FromResult(entity);
    }
}