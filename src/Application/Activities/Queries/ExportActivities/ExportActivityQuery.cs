using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Activities.Queries.ExportActivities;

public record ExportActivityQuery : IRequest<ExportActivityVm>
{
    public int Id { get; set; }
}

public class ExportActivityQueryHandler : IRequestHandler<ExportActivityQuery, ExportActivityVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;

    public ExportActivityQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportActivityVm> Handle(ExportActivityQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Activities
                                    .Where(a => a.Id == request.Id)
                                    .ProjectTo<ActivityRecord>(_mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);

        var vm = new ExportActivityVm(
            "Activities.csv",
            "text/csv",
            _fileBuilder.BuildActivityFile(records));

        return vm;
    }
}