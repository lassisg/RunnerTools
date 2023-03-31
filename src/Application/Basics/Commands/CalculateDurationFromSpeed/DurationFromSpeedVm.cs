using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Basics.Commands.CalculateDurationFromSpeed;

public class DurationFromSpeedVm : IMapFrom<RunningDurationVm>
{
    [Required] public decimal Distance { get; set; }
    [Required] public decimal Speed { get; set; }
    public TimeSpan Duration { get; set; }
}