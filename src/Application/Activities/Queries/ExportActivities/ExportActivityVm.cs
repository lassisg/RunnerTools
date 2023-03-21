namespace RunnerTools.Application.Activities.Queries.ExportActivities;

public class ExportActivityVm
{
    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
 
    public ExportActivityVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }
}