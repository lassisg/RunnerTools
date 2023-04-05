using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Application.Common.Models;

public class RunningCalculatorFullPlan : RunningCalculatorBase
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public RunningCalculatorFullPlan(RunningDto data) : base(data)
    {
    }
    
    public override RunningDto Calculate()
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