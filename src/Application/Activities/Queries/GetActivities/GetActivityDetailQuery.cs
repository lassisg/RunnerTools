using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dynastream.Fit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Activities.Queries.GetActivities;

public record GetActivityDetailQuery(int Id) : IRequest<ActivityVm>;

public class GetActivityDetailQueryHandler : IRequestHandler<GetActivityDetailQuery, ActivityVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActivityDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActivityVm> Handle(GetActivityDetailQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Activities
                                   .ProjectTo<ActivityVm>(_mapper.ConfigurationProvider)
                                   .SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Activity), request.Id);
        
        return entity;
    }
}