using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Common.Interfaces;

public interface IRunningCalculator
{
    public RunningData Data { get; set; }
    public  RunningData Calculate();
}