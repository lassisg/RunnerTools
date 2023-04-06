using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class SpeedFromCadenceCalculator : IRunningCalculator
{
    public IRunning Calculate(IRunning inputData)
    {
        var cadenceInMinutes = (decimal)inputData.Cadence.TotalMinutes;
        var speed = (int)TimeSpan.FromHours(1).TotalMinutes / cadenceInMinutes;
        
        var outputData = new Running
        {
            Cadence = inputData.Cadence,
            Speed = Decimal.Round(speed, 2)
        };
        
        return outputData;
    }
}