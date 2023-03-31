namespace RunnerTools.Domain.Entities;

public static class RunningSpeed
{
    // Based on the 50m World Record of 5.56 seconds
    private static readonly TimeSpan MaximumCadence = new(0,30,0);
    private static readonly TimeSpan MinimumCadence = new(0,2,0);

    public static decimal FromCadence (TimeSpan cadence)
    {
        if (cadence.TotalSeconds < MinimumCadence.TotalSeconds || cadence.TotalSeconds > MaximumCadence.TotalSeconds)
            throw new InvalidCadenceException(cadence);
        
        var cadenceInMinutes = (decimal)cadence.TotalMinutes;
        var speed = (int)TimeSpan.FromHours(1).TotalMinutes / cadenceInMinutes;
        var speedWithPrecision = Decimal.Round(speed, 2);
        
        return speedWithPrecision;  
    }

    public static decimal FromPlan(decimal distance, TimeSpan duration)
    {
        var durationInMinutes = (decimal)duration.TotalMinutes;

        var speed = (int)TimeSpan.FromHours(1).TotalMinutes * distance / durationInMinutes;
        var speedWithPrecision = Decimal.Round(speed, 2);

        return speedWithPrecision;
    }
}