using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningDurationQuery : IRequest<RunningDurationDto>;

public class GetRunningDurationQueryHandler : IRequestHandler<GetRunningDurationQuery,RunningDurationDto>
{
    public async Task<RunningDurationDto> Handle(GetRunningDurationQuery request, CancellationToken cancellationToken)
    {
        return new RunningDurationDto
        {
            Distance = 1,
            Duration = TimeSpan.FromMinutes(6),
            Cadence = TimeSpan.FromSeconds(0),
            Speed = 0
        };
    }
}