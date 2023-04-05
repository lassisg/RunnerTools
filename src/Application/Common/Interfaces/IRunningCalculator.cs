using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Common.Interfaces;

public interface IRunningCalculator
{
    public Running Data { get; set; }
    public  Running Calculate();
}