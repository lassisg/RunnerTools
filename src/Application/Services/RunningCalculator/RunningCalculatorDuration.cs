using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class RunningCalculatorDuration : IRunningCalculator
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public RunningCalculatorDuration(RunningData data)
    {
        Data = data;
    }

    public RunningData Data { get; set; }

    public RunningData Calculate()
    {
        decimal durationInSeconds;
        
        if (Data.Speed >= 1)
        {
            var duration = Data.Distance / Data.Speed;
            durationInSeconds = duration * (decimal)TimeSpan.FromHours(1).TotalSeconds;
        }
        else
        {
            var cadenceInSeconds = (decimal)Data.Cadence.TotalSeconds;
            durationInSeconds = cadenceInSeconds * Data.Distance;
        }
        
        var durationTotalSeconds = (int)Decimal.Round(durationInSeconds, 0);
        Data.Duration= TimeSpan.FromSeconds(durationTotalSeconds);
        
        return Data;
    }
    
}