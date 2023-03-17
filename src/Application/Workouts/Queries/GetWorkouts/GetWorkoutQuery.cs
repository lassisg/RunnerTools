using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public record GetWorkoutQuery : IRequest<WorkoutVm>;

public class GetWorkoutQueryHandler:IRequestHandler<GetWorkoutQuery, WorkoutVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkoutQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WorkoutVm> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
    {
        return new WorkoutVm
        {
            Lists = await _context.Workouts
                                  .AsNoTracking()
                                  .ProjectTo<WorkoutDto>(_mapper.ConfigurationProvider)
                                  .OrderBy(t => t.Name)
                                  .ToListAsync(cancellationToken)
        };
    }
}