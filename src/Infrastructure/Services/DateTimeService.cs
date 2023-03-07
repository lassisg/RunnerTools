using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
