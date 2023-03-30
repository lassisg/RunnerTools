using System.ComponentModel.DataAnnotations;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Simples.Commands.CalculateCadence;

public class MovementDto : IMapFrom<Simple>
{
    public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
}