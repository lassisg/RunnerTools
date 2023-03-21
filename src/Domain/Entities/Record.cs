namespace RunnerTools.Domain.Entities;

public class Record : BaseAuditableEntity
{
    public DateTime Timestamp { get; set; }
    public int Cadence { get; set; }
}