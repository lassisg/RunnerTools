using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public record GetWorkoutsQuery : IRequest<WorkoutsVm>;

public class GetWorkoutsQueryHandler:IRequestHandler<GetWorkoutsQuery, WorkoutsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkoutsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WorkoutsVm> Handle(GetWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var workouts = await _context.Workouts
                                     .AsNoTracking()
                                     .ProjectTo<WorkoutDto>(_mapper.ConfigurationProvider)
                                     .ToListAsync(cancellationToken);
        var workoutsVm = new WorkoutsVm
        {
            Workouts = workouts
        };
        
        return workoutsVm;
    }
}