namespace RunnerTools.Application.Workouts.Queries.ExportWorkouts;

public class ExportWorkoutVm
{

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public byte[] Content { get; set; }
    
    public ExportWorkoutVm(string fileName, string contentType, byte[] content)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = content;
    }
}