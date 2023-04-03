using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class RunningDurationDto : IMapFrom<RunningDto>
{
    [Required] public decimal Distance { get; set; }
    [Required] public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public TimeSpan Duration { get; set; }
}