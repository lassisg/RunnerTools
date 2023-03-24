using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Commands.CreateActivity;

public record CreateActivityCommand : IRequest<int>
{
    public string Name { get; set; }
    
    [Display(Name = "Time")]
    public DateTime LocalTimeStamp { get; set; }
    
    [Display(Name="Number of sessions")]
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
            Name = request.Name,
            LocalTimeStamp = request.LocalTimeStamp, 
            SessionCount = request.SessionCount,
            Sessions = request.Sessions
        };

        await _context.Activities.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}