namespace RunnerTools.Domain.Entities;

public class Activity : BaseAuditableEntity
{
    public DateTime LocalTimeStamp { get; set; }
    public int SessionCount { get; set; }
    public IList<Session> Sessions { get; set; } = new List<Session>();
}