using RunnerTools.Application.Common.Mappings;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Queries.GetBasics;

public class RunningDurationVm : IMapFrom<RunningDurationDto>
{
    public decimal Distance { get; set; }
    public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}