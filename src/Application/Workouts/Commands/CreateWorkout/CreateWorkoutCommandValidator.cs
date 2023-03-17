using FluentValidation;

namespace RunnerTools.Application.Workouts.Commands.CreateWorkout;

public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
{

    public CreateWorkoutCommandValidator()
    {
        RuleFor(w => w.Sport)
            .NotEmpty().WithMessage("Sport is required.");
        
        RuleFor(w => w.NumberOfValidSteps)
            .NotEmpty().WithMessage("Number of valid steps is required.");
    }
    
}