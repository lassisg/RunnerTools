using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Records.Queries.GetRecords;

public record GetRecordsQuery : IRequest<RecordVm>;

public class GetRecordsQueryHandler : IRequestHandler<GetRecordsQuery, RecordVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRecordsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RecordVm> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
    {
        return new RecordVm
        {
            Records = await _context.Records
                                     .AsNoTracking()
                                     .ProjectTo<RecordDto>(_mapper.ConfigurationProvider)
                                     .OrderBy(r => r.Timestamp)
                                     .ToListAsync(cancellationToken)
        };
    }
}