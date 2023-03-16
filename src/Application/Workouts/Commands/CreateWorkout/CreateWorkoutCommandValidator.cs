using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RunnerTools.Application.Common.Interfaces;

namespace RunnerTools.Application.Workouts.Commands.CreateWorkout;

public class CreateWorkoutCommandValidator : AbstractValidator<CreateWorkoutCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateWorkoutCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(w => w.Sport)
            .NotEmpty().WithMessage("Sport is required.");
        
        RuleFor(w => w.NumberOfValidSteps)
            .NotEmpty().WithMessage("Number of valid steps is required.");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
                             .AllAsync(l => l.Title != title, cancellationToken);
    }
    
}