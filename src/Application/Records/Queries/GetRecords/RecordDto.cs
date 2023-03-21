using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Records.Queries.GetRecords;

public class RecordDto : IMapFrom<Record>
{
    public DateTime Timestamp { get; set; }
    public int Cadence { get; set; }
}