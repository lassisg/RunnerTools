using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Queries.ExportWorkouts;

public record ExportWorkoutQuery : IRequest<ExportWorkoutVm>
{
    public int Id { get; init; }
}
    
public class ExportWorkoutQueryHandler : IRequestHandler<ExportWorkoutQuery,ExportWorkoutVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;

    public ExportWorkoutQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportWorkoutVm> Handle(ExportWorkoutQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Workouts
                                    .Where(w => w.Id == request.Id)
                                    .ProjectTo<WorkoutRecord>(_mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

        var vm = new ExportWorkoutVm(
            "Workouts.csv",
            "text/csv",
            _fileBuilder.BuildWorkoutFile(records));

        return vm;
    }
}