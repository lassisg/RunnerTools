using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;
using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Application.Services.RunningCalculator;

public class RunningCalculatorSpeedFromCadence : IRunningCalculator
{
    // Based on the 50m World Record of 5.56 seconds
    private static readonly TimeSpan MaximumCadence = new(0,30,0);
    private static readonly TimeSpan MinimumCadence = new(0,2,0);

    public RunningCalculatorSpeedFromCadence(RunningData data)
    {
        Data = data;
    }

    public RunningData Data { get; set; }

    public RunningData Calculate()
    {
        if (Data.Cadence.TotalSeconds < MinimumCadence.TotalSeconds || 
            Data.Cadence.TotalSeconds > MaximumCadence.TotalSeconds)
            throw new InvalidCadenceException(Data.Cadence);
        
        var cadenceInMinutes = (decimal)Data.Cadence.TotalMinutes;
        var speed = (int)TimeSpan.FromHours(1).TotalMinutes / cadenceInMinutes;
        
        Data.Speed = Decimal.Round(speed, 2);
        
        return Data;
    }
}