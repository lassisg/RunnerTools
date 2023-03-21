using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Commands.CreateActivity;

public record CreateActivityCommand : IRequest<int>
{
    public DateTime LocalTimeStamp { get; set; }
    public int SessionCount { get; set; }
    public IList<Session> Sessions { get; set; }
}

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        
        var entity = new Activity
        {
            LocalTimeStamp = request.LocalTimeStamp, 
            SessionCount = request.SessionCount,
            Sessions = request.Sessions
        };

        _context.Activities.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}