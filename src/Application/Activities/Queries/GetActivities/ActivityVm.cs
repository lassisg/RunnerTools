namespace RunnerTools.Application.Activities.Queries.GetActivities;

public class ActivityVm
{
    public IList<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
}