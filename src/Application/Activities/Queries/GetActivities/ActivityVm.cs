using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Activities.Queries.GetActivities;

public class ActivityVm : IMapFrom<Activity>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LocalTimeStamp { get; set; }
    public int SessionCount { get; set; }
}