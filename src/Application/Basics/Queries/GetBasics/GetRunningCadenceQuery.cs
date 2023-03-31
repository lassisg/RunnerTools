using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningCadenceQuery() : IRequest<RunningCadenceDto>;

public class GetRunningCadenceQueryHandler : IRequestHandler<GetRunningCadenceQuery, RunningCadenceDto>
{
    public async Task<RunningCadenceDto> Handle(GetRunningCadenceQuery request, CancellationToken cancellationToken)
    {
        return new RunningCadenceDto
        {
            Cadence = new TimeSpan(0, 0, 0), 
            Speed = 10M
        };
    }
}