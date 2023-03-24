using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Sessions.Queries.GetSessions;

public class LapDto : IMapFrom<Lap>
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
}