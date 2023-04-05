namespace RunnerTools.Application.Common.Models;

public abstract class RunningCalculatorBase
{

    public RunningDto Data { get; set; }
    
    protected RunningCalculatorBase(RunningDto data)
    {
        Data = data;
    }
    
    public abstract RunningDto Calculate();
    
    public static bool IsFullPlan(RunningDto data)
    {
        bool isFullPlan = data.Cadence.TotalSeconds == 0 && 
                          data.Speed == 0 &&
                          data.Distance >= 1 && 
                          data.Duration.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds;

        return isFullPlan;
    }
    
    public static bool IsDuration(RunningDto data)
    {
        bool isDuration = data.Duration.TotalSeconds == 0 && 
                          data.Distance >= 1 &&
                          (data.Speed > 2 ||
                           data.Cadence.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds);

        return isDuration;
    }
    
    public static bool IsSpeed(RunningDto data)
    {
        bool isSpeed = data.Speed == 0 &&
                       data.Distance == 0 &&
                       data.Duration.TotalSeconds == 0 &&
                       data.Cadence.TotalSeconds > TimeSpan.FromMinutes(2).TotalSeconds;

        return isSpeed;
    }
    
}
