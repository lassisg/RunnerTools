namespace RunnerTools.Domain.Entities;

public static class RunningDuration
{
    public static TimeSpan FromCadence(decimal distance, TimeSpan cadence)
    {
        var cadenceInSeconds = (decimal)cadence.TotalSeconds;

        var durationInSeconds = cadenceInSeconds * distance;
        var durationTotalSeconds = (int)Decimal.Round(durationInSeconds, 0);

        var targetDuration = new TimeSpan(0, 0, durationTotalSeconds);

        return targetDuration;
    }
    
    public static TimeSpan FromSpeed(decimal distance, decimal speed)
    {
        var duration = distance / speed;
        
        var durationInSeconds = duration * (decimal)TimeSpan.FromHours(1).TotalSeconds;
        var durationTotalSeconds = (int)Decimal.Round(durationInSeconds, 0);
        
        var targetDuration = TimeSpan.FromSeconds(durationTotalSeconds);



        var cadence = RunningCadence.FromSpeed(speed);
        var otherResult = FromCadence(distance, cadence);
        
        return targetDuration;
    }
}