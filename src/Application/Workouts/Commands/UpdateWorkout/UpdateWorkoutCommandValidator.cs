using FluentValidation;

namespace RunnerTools.Application.Workouts.Commands.UpdateWorkout;

public class UpdateWorkoutCommandValidator : AbstractValidator<UpdateWorkoutCommand>
{
    public UpdateWorkoutCommandValidator()
    {
        RuleFor(w => w.Sport)
            .NotEmpty().WithMessage("Sport is required.");
        
        RuleFor(w => w.NumberOfValidSteps)
            .NotEmpty().WithMessage("Number of valid steps is required.");
    }
}