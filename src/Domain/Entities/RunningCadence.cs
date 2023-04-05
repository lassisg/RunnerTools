namespace RunnerTools.Domain.Entities;

public static class RunningCadence
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public static TimeSpan FromSpeed (decimal speed)
    {
        if (speed is < MinimumSpeed or > MaximumSpeed)
            throw new InvalidSpeedException(speed);
            
        var cadenceInSeconds = (int)TimeSpan.FromHours(1).TotalSeconds / speed;
        var totalSeconds = (int)Decimal.Round(cadenceInSeconds);
        var cadence = new TimeSpan(0, 0, totalSeconds);
        
        return cadence;
    }

    public static TimeSpan FromPlan(decimal distance, TimeSpan duration)
    {
        var durationInSeconds = (decimal)duration.TotalSeconds;

        var cadenceInSeconds = durationInSeconds / distance;
        var cadenceTotalSeconds = (int)Decimal.Round(cadenceInSeconds, 0);

        var targetCadence = new TimeSpan(0, 0, cadenceTotalSeconds);

        return targetCadence;
    }
}