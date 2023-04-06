using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class FullPlanCalculator : IRunningCalculator
{
    public IRunning Calculate(IRunning inputData)
    {
        var durationInSeconds = (decimal)inputData.Duration.TotalSeconds;
        var cadenceInSeconds = durationInSeconds / inputData.Distance;

        var cadenceTotalSeconds = (int)Decimal.Round(cadenceInSeconds, 0);
        var speed = (int)TimeSpan.FromHours(1).TotalSeconds * inputData.Distance / durationInSeconds;

        var outputData = new Running
        {
            Cadence = TimeSpan.FromSeconds(cadenceTotalSeconds),
            Speed = Decimal.Round(speed, 2), 
            Distance = inputData.Distance,
            Duration = inputData.Duration
        };

        return outputData;
    }
}