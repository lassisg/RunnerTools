using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Sessions.Queries.GetSessions;

public class SessionDto : IMapFrom<Session>
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
    public IList<LapDto>? Laps { get; set; }

    public SessionDto()
    {
        Laps = new List<LapDto>();
    }
}