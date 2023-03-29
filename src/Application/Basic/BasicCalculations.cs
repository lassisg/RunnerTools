﻿using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basic;

public static class BasicCalculations
{
    private const int MinutesInHour = 60;
    private const int SecondsInMinute = 60;
    
    public static TimeSpan SpeedToCadence(decimal speed)
    {
        var cadenceInSeconds = MinutesInHour * SecondsInMinute / speed;
        var totalSeconds = (int)Decimal.Round(cadenceInSeconds);
        var cadence = new TimeSpan(0, 0, totalSeconds);

        return cadence;
    }
    
    public static decimal CadenceToSpeed(TimeSpan cadence)
    {
        var cadenceInMinutes =(decimal)cadence.TotalMinutes;
        var speed = MinutesInHour / cadenceInMinutes;
        var speedWithPrecision = Decimal.Round(speed, 2);
        
        return speedWithPrecision;
    }
    
    public static TimeSpan GetTargetCadence(decimal distance, TimeSpan duration)
    {
        var durationInSeconds = (decimal)duration.TotalSeconds;
        
        var cadenceInSeconds = durationInSeconds / distance;
        var cadenceTotalSeconds = (int)Decimal.Round(cadenceInSeconds, 0);
        
        var targetCadence = new TimeSpan(0, 0, cadenceTotalSeconds);
        
        return targetCadence;
    }

    public static decimal GetTargetSpeed(decimal distance, TimeSpan duration)
    {
        var durationInMinutes = (decimal)duration.TotalMinutes;
        
        var speed = MinutesInHour * distance / durationInMinutes;
        var speedWithPrecision = Decimal.Round(speed, 2);
        
        return speedWithPrecision;
    }
    
    public static TimeSpan GetTargetDuration(decimal distance, TimeSpan cadence)
    {
        var cadenceInSeconds = (decimal)cadence.TotalSeconds;
        
        var durationInSeconds = cadenceInSeconds * distance;
        var durationTotalSeconds = (int)Decimal.Round(durationInSeconds, 0);
        
        var targetDuration = new TimeSpan(0, 0, durationTotalSeconds);
        
        return targetDuration;
    }
}
