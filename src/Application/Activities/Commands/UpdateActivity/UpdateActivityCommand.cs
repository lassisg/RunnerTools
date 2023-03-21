using MediatR;
using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Commands.UpdateActivity;

public record UpdateActivityCommand : IRequest<int>
{
    public int Id { get; set; }
    public DateTime LocalTimeStamp { get; set; }
    public int SessionCount { get; set; }
    public IList<Session> Sessions { get; set; }
}

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Activities
                                   .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Activity), request.Id);
        }

        entity.LocalTimeStamp = request.LocalTimeStamp;
        entity.SessionCount = request.SessionCount;
        entity.Sessions = request.Sessions;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}