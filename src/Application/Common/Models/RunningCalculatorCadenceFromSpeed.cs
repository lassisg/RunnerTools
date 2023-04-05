using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Application.Common.Models;

public class RunningCalculatorCadenceFromSpeed : RunningCalculatorBase
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public RunningCalculatorCadenceFromSpeed(RunningDto data) : base(data)
    {
    }
    
    public override RunningDto Calculate()
    {
        if (Data.Speed is < MinimumSpeed or > MaximumSpeed)
            throw new InvalidSpeedException(Data.Speed);
            
        var cadenceInSeconds = (int)TimeSpan.FromHours(1).TotalSeconds / Data.Speed;
        var totalSeconds = (int)Decimal.Round(cadenceInSeconds);
        
        Data.Cadence = TimeSpan.FromSeconds(totalSeconds);
        
        return Data;
    }
}