using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<Workout>, IMapFrom<WorkoutStep>
{
    public int Id { get; set; }

    public string? Name { get; set; }
}
