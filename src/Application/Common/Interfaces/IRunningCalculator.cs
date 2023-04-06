using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Common.Interfaces;

public interface IRunningCalculator
{
    public IRunning Calculate(IRunning inputData);
}