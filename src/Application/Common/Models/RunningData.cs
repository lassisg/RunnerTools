using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class RunningData : IMapFrom<Running>, IRunning
{
    public decimal Distance { get; set; }
    public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}