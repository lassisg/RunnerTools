using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public record GetRunningQuery : IRequest<RunningData>;

public class GetRunningDurationQueryHandler : IRequestHandler<GetRunningQuery, RunningData>
{
    public Task<RunningData> Handle(GetRunningQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new RunningData());
    }
}