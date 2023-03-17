namespace RunnerTools.Domain.Events;

public class WorkoutCreatedEvent : BaseEvent
{
    public WorkoutCreatedEvent(Workout item)
    {
        Item = item;
    }

    public Workout Item { get; }
}
