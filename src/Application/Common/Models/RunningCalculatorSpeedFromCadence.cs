using RunnerTools.Domain.Exceptions;

namespace RunnerTools.Application.Common.Models;

public class RunningCalculatorSpeedFromCadence : RunningCalculatorBase
{
    // Based on the 50m World Record of 5.56 seconds
    private static readonly TimeSpan MaximumCadence = new(0,30,0);
    private static readonly TimeSpan MinimumCadence = new(0,2,0);

    public RunningCalculatorSpeedFromCadence(RunningDto data) : base(data)
    {
    }
    
    public override RunningDto Calculate()
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