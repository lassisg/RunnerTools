namespace RunnerTools.Domain.Entities;

public class WorkoutStep
{
    public int Index { get; set; }
    public string? Name { get; set; }
    public StepDuration DurationType { get; set; } = StepDuration.Distance;
    public int Duration { get; set; } = 1;
    public StepTarget TargetType { get; set; } = StepTarget.Cadence;
    public int? TargetValue { get; set; }
    public int? TargetLow { get; set; }
    public int? TargetHigh { get; set; }
    public Intensity? Intensity { get; set; }
    public string? Notes { get; set; }

}