using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public static class RunningCalculatorFactory
{
    public static IRunningCalculator GetRunningCalculator(RunningData runningData)
    {
        if (IsFullPlan(runningData)) 
            return new RunningCalculatorFullPlan(runningData);
        
        if (IsDuration(runningData)) 
            return new RunningCalculatorDuration(runningData);
        
        if (IsSpeed(runningData)) 
            return new RunningCalculatorSpeedFromCadence(runningData);

        return new RunningCalculatorCadenceFromSpeed(runningData);
    }

    private static bool IsFullPlan(RunningData data)
    {
        bool isFullPlan = data.Cadence.TotalSeconds == 0 && 
                          data.Speed == 0 &&
                          data.Distance >= 1 && 
                          data.Duration.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds;

        return isFullPlan;
    }

    private static bool IsDuration(RunningData data)
    {
        bool isDuration = data.Duration.TotalSeconds == 0 && 
                          data.Distance >= 1 &&
                          (data.Speed > 2 ||
                           data.Cadence.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds);

        return isDuration;
    }

    private static bool IsSpeed(RunningData data)
    {
        bool isSpeed = data.Speed == 0 &&
                       data.Distance == 0 &&
                       data.Duration.TotalSeconds == 0 &&
                       data.Cadence.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds;

        return isSpeed;
    }

}