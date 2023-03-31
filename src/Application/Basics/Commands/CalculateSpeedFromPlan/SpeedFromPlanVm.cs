using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Commands.CalculateSpeedFromPlan;

public class SpeedFromPlanVm : IMapFrom<RunningDurationDto>
{
    [Required] public decimal Distance { get; set; }
    [Required] public TimeSpan Duration { get; set; }
    public decimal Speed { get; set; }
}