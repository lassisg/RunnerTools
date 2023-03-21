using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Sessions.Queries.GetSessions;

public record GetSessionQuery : IRequest<SessionVm>;

public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, SessionVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSessionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SessionVm> Handle(GetSessionQuery request, CancellationToken cancellationToken)
    {
        return new SessionVm
        {
            Sessions = await _context.Workouts
                                     .AsNoTracking()
                                     .ProjectTo<SessionDto>(_mapper.ConfigurationProvider)
                                     .OrderBy(s => s.Timestamp)
                                     .ToListAsync(cancellationToken)
        };
    }
}