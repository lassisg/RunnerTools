using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromSpeed;

public record CalculateCadenceFromSpeedCommand(decimal speed) : IRequest<RunningSpeedDto>;

public class CalculateCadenceFromSpeedCommandHandler : IRequestHandler<CalculateCadenceFromSpeedCommand, RunningSpeedDto>
{
    public Task<RunningSpeedDto> Handle(CalculateCadenceFromSpeedCommand request, CancellationToken cancellationToken)
    {
        var entity = new RunningSpeedDto()
        {
            Speed = request.speed,
            Cadence = RunningCadence.FromSpeed(request.speed) 
        };

        return Task.FromResult(entity);
    }
}