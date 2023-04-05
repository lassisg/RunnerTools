using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Application.Services.RunningCalculator;

public class RunningCalculatorCadenceFromSpeed : IRunningCalculator
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;

    public RunningData Data { get; set; }

    public RunningCalculatorCadenceFromSpeed(RunningData data)
    {
        Data = data;
    }

    public RunningData Calculate()
    {
        if (Data.Speed is < MinimumSpeed or > MaximumSpeed)
            throw new InvalidSpeedException(Data.Speed);
            
        var cadenceInSeconds = (int)TimeSpan.FromHours(1).TotalSeconds / Data.Speed;
        var totalSeconds = (int)Decimal.Round(cadenceInSeconds);
        
        Data.Cadence = TimeSpan.FromSeconds(totalSeconds);
        
        return Data;
    }
}