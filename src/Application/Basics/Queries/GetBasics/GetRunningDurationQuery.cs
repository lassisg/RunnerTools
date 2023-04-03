using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningDurationQuery : IRequest<RunningDurationVm>;

public class GetRunningDurationQueryHandler : IRequestHandler<GetRunningDurationQuery,RunningDurationVm>
{
    public async Task<RunningDurationVm> Handle(GetRunningDurationQuery request, CancellationToken cancellationToken)
    {
        return new RunningDurationVm
        {
            Distance = 1,
            Duration = TimeSpan.FromMinutes(6),
            Speed = 0,
            Cadence = TimeSpan.FromSeconds(0),
        };
    }
}