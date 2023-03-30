namespace RunnerTools.Domain.Entities;

public class Simple : BaseAuditableEntity
{
    public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
    public decimal Distance { get; set; }
    public TimeSpan Duration { get; set; }
    
    // private const int MinutesInHour = 60;
    // private const int SecondsInMinute = 60;
    //
    // // Based on the 50m World Record of 5.56 seconds
    // private const decimal MaximumSpeed = 30M;
    // private const decimal MinimumSpeed = 2M;
    // private static readonly TimeSpan MaximumCadence = new(0,30,0);
    // private static readonly TimeSpan MinimumCadence = new(0,2,0);
}