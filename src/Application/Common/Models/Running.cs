namespace RunnerTools.Application.Common.Models;

public class Running
{
    public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
    public decimal Distance { get; set; }
    public TimeSpan Duration { get; set; }
}