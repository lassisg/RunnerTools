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
}