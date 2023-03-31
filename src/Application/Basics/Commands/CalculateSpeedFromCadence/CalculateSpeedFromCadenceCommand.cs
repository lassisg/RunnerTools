using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateSpeedFromCadence;


public record CalculateSpeedFromCadenceCommand(TimeSpan cadence) : IRequest<RunningCadenceDto>;

public class CalculateSpeedFromCadenceCommandHandler : IRequestHandler<CalculateSpeedFromCadenceCommand, RunningCadenceDto>
{
    public Task<RunningCadenceDto> Handle(CalculateSpeedFromCadenceCommand request, CancellationToken cancellationToken)
    {
        var entity = new RunningCadenceDto()
        {
            Cadence = request.cadence, 
            Speed = RunningSpeed.FromCadence(request.cadence)
        };

        return Task.FromResult(entity);
    }
}