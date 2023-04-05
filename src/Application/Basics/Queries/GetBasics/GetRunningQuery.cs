using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningQuery : IRequest<RunningDto>;

public class GetRunningDurationQueryHandler : IRequestHandler<GetRunningQuery,RunningDto>
{
    public Task<RunningDto> Handle(GetRunningQuery request, CancellationToken cancellationToken)
    {
        // return new RunningDto
        // {
        //     Distance = 1,
        //     Duration = TimeSpan.FromMinutes(6),
        //     Cadence = TimeSpan.FromSeconds(6),
        //     Speed = 10
        // };
        return Task.FromResult(new RunningDto());
    }
}