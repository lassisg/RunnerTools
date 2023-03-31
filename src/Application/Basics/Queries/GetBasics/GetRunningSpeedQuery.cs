using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningSpeedQuery() : IRequest<RunningSpeedDto>;

public class GetRunningSpeedQueryHandler : IRequestHandler<GetRunningSpeedQuery, RunningSpeedDto>
{
    public async Task<RunningSpeedDto> Handle(GetRunningSpeedQuery request, CancellationToken cancellationToken)
    {
        return new RunningSpeedDto
        {
            Cadence = new TimeSpan(0, 0, 0), 
            Speed = 10M
        };
    }
}