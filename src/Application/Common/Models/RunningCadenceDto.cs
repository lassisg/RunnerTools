using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;

namespace RunnerTools.Application.Common.Models;

public class RunningCadenceDto : IMapFrom<RunningDto>
{
    [Required] public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
    public decimal Distance { get; set; }
}
