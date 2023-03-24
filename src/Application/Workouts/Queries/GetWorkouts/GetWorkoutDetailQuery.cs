using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public record GetWorkoutDetailQuery(int Id) : IRequest<WorkoutVm>;

public class GetWorkoutDetailQueryHandler : IRequestHandler<GetWorkoutDetailQuery, WorkoutVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWorkoutDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WorkoutVm> Handle(GetWorkoutDetailQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Workouts
                                   .ProjectTo<WorkoutVm>(_mapper.ConfigurationProvider)
                                   .SingleOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Workout), request.Id);
        
        return entity;
    }
}