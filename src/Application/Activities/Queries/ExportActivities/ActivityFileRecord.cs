using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Queries.ExportActivities;

public class ActivityRecord : IMapFrom<Activity>
{
    public string? Name { get; set; }
    public bool Done { get; set; }
}