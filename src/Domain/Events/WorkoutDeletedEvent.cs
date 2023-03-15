namespace RunnerTools.Domain.Events;

public class WorkoutDeletedEvent : BaseEvent
{
    public WorkoutDeletedEvent(Workout item)
    {
        Item = item;
    }

    public Workout Item { get; }
}