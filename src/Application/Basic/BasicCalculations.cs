namespace RunnerTools.Application.Basic;

public static class BasicCalculations
{
    private const int MinutesInHour = 60;
    private const int SecondsInMinute = 60;
    
    public static TimeSpan ToCadence(this decimal speed)
    {
        var cadenceNumeric = MinutesInHour / speed;
        var cadenceMinutes = (int)cadenceNumeric;
        var cadenceSeconds = (int)((cadenceNumeric - cadenceMinutes) * SecondsInMinute);
        
        return new TimeSpan(0, cadenceMinutes, cadenceSeconds);
    }
    
    public static decimal ToSpeed(this TimeSpan cadence)
    {
        var cadenceMinutes = cadence.Minutes;
        var cadenceSeconds = cadence.Seconds;
        decimal cadenceNumeric = cadenceMinutes + (decimal)cadenceSeconds/SecondsInMinute;
        decimal speed = MinutesInHour / cadenceNumeric;
        
        return Decimal.Round(speed,2);
    }
}

public class Timespan
{
}