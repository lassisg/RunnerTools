namespace RunnerTools.Application.Common.Models;

public class RunningCalculatorDuration : RunningCalculatorBase
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public RunningCalculatorDuration(RunningDto data) : base(data)
    {
    }
    
    public override RunningDto Calculate()
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