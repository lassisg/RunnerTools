using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class RunningCalculatorFullPlan : IRunningCalculator
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public Running Data { get; set; }

    public RunningCalculatorFullPlan(Running data)
    {
        Data = data;
    }

    public Running Calculate()
    {
        var durationInSeconds = (decimal)Data.Duration.TotalSeconds;
        var cadenceInSeconds = durationInSeconds / Data.Distance;

        var cadenceTotalSeconds = (int)Decimal.Round(cadenceInSeconds, 0);
        var speed = (int)TimeSpan.FromHours(1).TotalSeconds * Data.Distance / durationInSeconds;
        
        Data.Speed = Decimal.Round(speed, 2);
        Data.Cadence = TimeSpan.FromSeconds(cadenceTotalSeconds);
        
        return Data;
    }
}