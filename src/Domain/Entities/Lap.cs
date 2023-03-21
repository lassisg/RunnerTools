namespace RunnerTools.Domain.Entities;

public class Lap : BaseAuditableEntity
{
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }
}