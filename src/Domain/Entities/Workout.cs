namespace RunnerTools.Domain.Entities;

public class Workout : BaseAuditableEntity
{
    public Sport Sport { get; set; }
    public string? Capabilities { get; set; }
    public int NumberOfValidSteps { get; set; }
    public string? Name { get; set; }
    public SubSport? SubSport { get; set; }
    public int? PoolLenghtInMeters { get; set; }
    public DisplayMeasure? PoolLenghtUnit { get; set; } = DisplayMeasure.Metric;
    public ICollection<WorkoutStep> WorkoutSteps { get; set; } = default!;
}