using MediatR;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Basics.Commands.CalculateDurationFromCadence;


public record CalculateDurationFromCadenceCommand(decimal distance, TimeSpan cadence) : IRequest<DurationFromCadenceVm>;

public class CalculateDurationFromCadenceCommandHandler : IRequestHandler<CalculateDurationFromCadenceCommand, DurationFromCadenceVm>
{
    public Task<DurationFromCadenceVm> Handle(CalculateDurationFromCadenceCommand request, CancellationToken cancellationToken)
    {
        var entity = new DurationFromCadenceVm()
        {
            Distance = request.distance, 
            Cadence = request.cadence, 
            Duration = RunningDuration.FromCadence(request.distance, request.cadence)
        };

        return Task.FromResult(entity);
    }
}