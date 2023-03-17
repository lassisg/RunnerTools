using FluentValidation;

namespace RunnerTools.Application.WorkoutSteps.Commands.UpdateWorkoutStep;

public class UpdateWorkoutStepCommandValidator : AbstractValidator<UpdateWorkoutStepCommand>
{
    public UpdateWorkoutStepCommandValidator()
    {
        RuleFor(s => s.WorkoutId)
            .NotEmpty().WithMessage("Workout id is required.");
        
        RuleFor(s => s.Index)
            .NotEmpty().WithMessage("Step index is required.");
    }
}