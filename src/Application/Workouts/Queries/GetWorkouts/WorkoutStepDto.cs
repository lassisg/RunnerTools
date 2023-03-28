using AutoMapper;
using RunnerTools.Application.Common.Mappings;
using RunnerTools.Domain.Entities;

namespace RunnerTools.Application.Workouts.Queries.GetWorkouts;

public class WorkoutStepDto : IMapFrom<WorkoutStep>
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public string? Name { get; set; }

    public string StepDuration { get; set; }

    public int Duration { get; set; }

    public string? StepTarget { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<WorkoutStep, WorkoutStepDto>()
               .ForMember(w => w.StepDuration, opt => opt.MapFrom(s => s.DurationType.ToString()));
        profile.CreateMap<WorkoutStep, WorkoutStepDto>()
               .ForMember(w => w.StepTarget, opt => opt.MapFrom(s => s.TargetType.ToString()));
    }
}