using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class RunningSpeedDto : IMapFrom<RunningDto>
{
    [Required] public decimal Speed { get; set; }
    public TimeSpan Cadence { get; set; }
    public decimal Distance { get; set; }
}