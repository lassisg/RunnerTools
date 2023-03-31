using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Basics.Commands.CalculateDurationFromCadence;

public class DurationFromCadenceVm : IMapFrom<RunningDurationVm>
{
    [Required] public decimal Distance { get; set; }
    [Required] public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}