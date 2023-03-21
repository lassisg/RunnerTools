namespace RunnerTools.Application.Records.Queries.GetRecords;

public class RecordVm
{
    public IList<RecordDto> Records { get; set; } = new List<RecordDto>();
}