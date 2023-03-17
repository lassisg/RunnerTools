using FluentValidation;

namespace RunnerTools.Application.WorkoutSteps.Commands.CreateWorkoutStep;

public class CreateWorkoutStepCommandValidator : AbstractValidator<CreateWorkoutStepCommand>
{
    public CreateWorkoutStepCommandValidator()
    {
        RuleFor(s => s.WorkoutId)
            .NotEmpty().WithMessage("Workout id is required.");
        
        RuleFor(s => s.Index)
            .NotEmpty().WithMessage("Step index is required.");
    }
}