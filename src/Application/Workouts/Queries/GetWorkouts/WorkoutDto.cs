﻿using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public class WorkoutDto : IMapFrom<Workout>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Sport { get; set; }
    public int NumberOfValidSteps { get; set; }
    public IList<WorkoutStepDto> WorkoutSteps { get; set; }
    
    public WorkoutDto()
    {
        WorkoutSteps = new List<WorkoutStepDto>();
    }
    
}