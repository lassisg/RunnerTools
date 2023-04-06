using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class Running : IMapFrom<RunningData>, IRunning
{
    public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
    public decimal Distance { get; set; }
    public TimeSpan Duration { get; set; }
}