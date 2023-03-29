namespace RunnerTools.Domain.Exceptions;

public class InvalidCadenceException : Exception
{
    public InvalidCadenceException(TimeSpan cadence)
        : base($"Invalid cadence '{cadence.Minutes}:{cadence.Seconds}'.")
    {
    }
}