using System.ComponentModel.DataAnnotations;

namespace RunnerTools.Domain.Entities;

public class Activity : BaseAuditableEntity
{
    public string Name { get; set; }
    public DateTime LocalTimeStamp { get; set; }
    
    [Display(Name = "Number of sessions")]
    public int SessionCount { get; set; }
    public IList<Session> Sessions { get; set; } = new List<Session>();
}