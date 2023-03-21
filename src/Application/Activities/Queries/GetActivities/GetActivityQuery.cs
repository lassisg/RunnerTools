using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Activities.Queries.GetActivities;

public record GetActivityQuery : IRequest<ActivityVm>;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery,ActivityVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActivityQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActivityVm> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        return new ActivityVm
        {
            Activities = await _context.Workouts
                                     .AsNoTracking()
                                     .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                                     .OrderBy(a => a.LocalTimeStamp)
                                     .ToListAsync(cancellationToken)
        };
    }
}