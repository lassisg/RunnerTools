using RunnerTools.Application.Common.Exceptions;
using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Services.RunningCalculator;

public static class RunningCalculatorFactory
{
    private static readonly decimal MINIMUM_SPEED = 2m;
    private static readonly TimeSpan MINIMUM_CADENCE = TimeSpan.FromMinutes(2);
    private static readonly TimeSpan MINIMUM_DURATION= TimeSpan.FromMinutes(2);
    
    public static IRunningCalculator GetRunningCalculator(IRunning runningData)
    {
        if (IsCadenceFromSpeed(runningData))
            return new CadenceFromSpeedCalculator();
        
        if (IsSpeedFromCadence(runningData))
            return new SpeedFromCadenceCalculator();
        
        if (IsFullPlan(runningData))
            return new FullPlanCalculator();
        
        if (IsDurationFromCadence(runningData))
            return new DurationFromCadenceCalculator();
        
        if (IsDurationFromSpeed(runningData))
            return new DurationFromSpeedCalculator();

        throw new CalculatorException();
    }

    private static bool IsCadenceFromSpeed(IRunning inputData)
    {
        bool isCadenceFromSpeed = inputData.Speed > 2 &&
                                  inputData is { 
                                      Cadence.TotalSeconds: 0, 
                                      Distance: 0, 
                                      Duration.TotalSeconds: 0 };

        return isCadenceFromSpeed;
    }

    private static bool IsSpeedFromCadence(IRunning inputData)
    {
        bool isSpeedFromCadence = inputData.Cadence > MINIMUM_CADENCE &&
                                  inputData is {
                                      Speed: 0,
                                      Distance: 0,
                                      Duration.TotalSeconds: 0 };

        return isSpeedFromCadence;
    }
    
    private static bool IsFullPlan(IRunning inputData)
    {
        bool isSpeedFromPlan = inputData.Distance >= 1 &&
                               inputData.Duration > MINIMUM_DURATION &&
                               inputData is {
                                   Speed: 0,
                                   Cadence.TotalSeconds: 0 };

        return isSpeedFromPlan;
    }

    private static bool IsDurationFromCadence(IRunning inputData)
    {
        bool isDurationFromCadence = inputData.Cadence >= MINIMUM_CADENCE &&
                                     inputData.Distance >= 1 &&
                                     inputData is {
                                         Speed: 0,
                                         Duration.TotalSeconds: 0 };

        return isDurationFromCadence;
    }

    private static bool IsDurationFromSpeed(IRunning inputData)
    {
        bool isDurationFromSpeed = inputData.Speed >= MINIMUM_SPEED &&
                                   inputData.Distance >= 1 &&
                                   inputData is {
                                       Cadence.TotalSeconds: 0,
                                       Duration.TotalSeconds: 0 };

        return isDurationFromSpeed;
    }

}