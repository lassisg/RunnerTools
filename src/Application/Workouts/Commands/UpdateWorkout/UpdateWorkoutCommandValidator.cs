using FluentValidation;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Commands.UpdateWorkout;

public class UpdateWorkoutCommandValidator : AbstractValidator<UpdateWorkoutCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateWorkoutCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(w => w.Sport)
            .NotEmpty().WithMessage("Sport is required.");
        
        RuleFor(w => w.NumberOfValidSteps)
            .NotEmpty().WithMessage("Number of valid steps is required.");
    }
}