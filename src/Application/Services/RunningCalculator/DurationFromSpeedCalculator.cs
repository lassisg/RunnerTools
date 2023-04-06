using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class DurationFromSpeedCalculator : IRunningCalculator
{
    public IRunning Calculate(IRunning inputData)
    {
    
        var duration = inputData.Distance / inputData.Speed;
        var durationInSeconds = (int)Decimal
            .Round(duration * (decimal)TimeSpan.FromHours(1).TotalSeconds,
                   0);
        
        var outputData = new Running
        {
            Speed = inputData.Speed,
            Distance = inputData.Distance,
            Duration = TimeSpan.FromSeconds(durationInSeconds)
        };
        
        return outputData;
    }
}