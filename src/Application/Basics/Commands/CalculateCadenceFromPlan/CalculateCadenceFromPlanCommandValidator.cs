using FluentValidation;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;

public class CalculateCadenceFromPlanCommandValidator : AbstractValidator<CalculateCadenceFromPlanCommand>
{
    // Based on the 50m World Record of 5.56 seconds
    private const int MinimumDuration = 2;
    private const decimal MinimumDistance = 1M;
    
    public CalculateCadenceFromPlanCommandValidator()
    {
        RuleFor(c => c.duration.TotalMinutes)
            .NotEmpty().WithMessage("Duration is required.")
            .GreaterThan(MinimumDuration).WithMessage("Duration must be greater than 2 minutes.");
        RuleFor(c => c.distance)
            .NotEmpty().WithMessage("Distance is required.")
            .GreaterThanOrEqualTo(MinimumDistance).WithMessage("Distance must be greater than or equal to 1 km.");
    }
}