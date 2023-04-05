using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Activities.Queries.GetActivities;

public record GetActivitiesQuery : IRequest<ActivitiesVm>;

public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, ActivitiesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActivitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActivitiesVm> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = await _context.Activities
                                       .AsNoTracking()
                                       .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);
        var activitiesVm = new ActivitiesVm
        {
            Activities = activities
        };
        
        return activitiesVm;
    }
}