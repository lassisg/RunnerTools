namespace RunnerTools.Application.Sessions.Queries.GetSessions;

public class SessionVm
{
    public IList<SessionDto> Sessions { get; set; } = new List<SessionDto>();
}