using RunnerTools.Application.Common.Mappings;
using RunnerTools.Application.Sessions.Queries.GetSessions;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Queries.GetActivities;

public class ActivityDto : IMapFrom<Activity>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LocalTimeStamp { get; set; }
    public int SessionCount { get; set; }
    public IList<SessionDto> Sessions { get; set; }

    public ActivityDto()
    {
        Sessions = new List<SessionDto>();
    }
}