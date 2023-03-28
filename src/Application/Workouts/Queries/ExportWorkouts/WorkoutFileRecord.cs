using AutoMapper;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Workouts.Queries.ExportWorkouts;

public class WorkoutRecord : IMapFrom<Workout>
{
    public string Name { get; set; }
}