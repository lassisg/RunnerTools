namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public class WorkoutsVm
{
    public IList<WorkoutDto> Workouts { get; set; } = new List<WorkoutDto>();
    
}