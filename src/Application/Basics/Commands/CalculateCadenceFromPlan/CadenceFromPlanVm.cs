using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;

public class CadenceFromPlanVm : IMapFrom<RunningDurationDto>
{
    [Required] public decimal Distance { get; set; }
    [Required] public TimeSpan Duration { get; set; }
    public TimeSpan Cadence { get; set; }
}