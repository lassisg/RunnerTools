using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class DurationFromCadenceCalculator : IRunningCalculator
{
    public IRunning Calculate(IRunning inputData)
    {
        var cadenceInSeconds = (decimal)inputData.Cadence.TotalSeconds;
        var durationInSeconds = (int)Decimal
            .Round(cadenceInSeconds * inputData.Distance, 
                   0);
        
        var outputData = new Running
        {
            Cadence = inputData.Cadence,
            Distance = inputData.Distance,
            Duration = TimeSpan.FromSeconds(durationInSeconds)
        };
        
        return outputData;
    }
}