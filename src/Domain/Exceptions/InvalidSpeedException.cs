namespace RunnerTools.Domain.Exceptions;

public class InvalidSpeedException : Exception
{
    public InvalidSpeedException(decimal speed)
        : base($"Invalid speed '{speed}'.")
    {
    }
}