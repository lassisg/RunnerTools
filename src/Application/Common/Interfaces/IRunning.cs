namespace RunnerTools.Application.Common.Interfaces;

public interface IRunning
{
    public TimeSpan Cadence { get; set; }
    public decimal Speed { get; set; }
    public decimal Distance { get; set; }
    public TimeSpan Duration { get; set; }
}