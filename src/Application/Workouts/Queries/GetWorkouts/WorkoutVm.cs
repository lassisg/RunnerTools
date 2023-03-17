namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public class WorkoutVm
{
    public IList<WorkoutDto> Workouts { get; set; } = new List<WorkoutDto>();
    
}