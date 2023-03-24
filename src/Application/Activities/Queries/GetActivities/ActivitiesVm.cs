namespace RunnerTools.Application.Activities.Queries.GetActivities;

public class ActivitiesVm
{
    public IList<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
}