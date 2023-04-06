using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public class CadenceFromSpeedCalculator: IRunningCalculator
{
    public IRunning Calculate(IRunning inputData)
    {
        var cadence = (int)TimeSpan.FromHours(1).TotalSeconds / inputData.Speed;
        var cadenceInSeconds = (int)Decimal.Round(cadence);
        
        var outputData = new Running
        {
            Speed = inputData.Speed,
            Cadence = TimeSpan.FromSeconds(cadenceInSeconds)
        };
        
        return outputData;
    }
}