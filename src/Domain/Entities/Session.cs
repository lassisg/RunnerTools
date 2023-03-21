namespace RunnerTools.Domain.Entities;

public class Session : BaseAuditableEntity
{
    public DateTime StartTime { get; set; }
    public DateTime TotalElapsedTime { get; set; }
    public DateTime TotalTimerTime { get; set; }
    public DateTime Timestamp { get; set; }

    public Sport? Sport { get; set; }
    public SubSport? SubSport { get; set; }
    public int? TotalDuration { get; set; }
    public int? Distance { get; set; }
    public IList<Lap>? Laps { get; set; }
}