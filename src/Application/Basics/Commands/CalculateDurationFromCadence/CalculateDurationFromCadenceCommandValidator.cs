using FluentValidation;
using RunnerTools.Application.Basics.Commands.CalculateSpeedFromCadence;

namespace RunnerTools.Application.Basics.Commands.CalculateDurationFromCadence;

public class CalculateDurationFromCadenceCommandValidator : AbstractValidator<CalculateDurationFromCadenceCommand>
{
    // Based on the 50m World Record of 5.56 seconds
    private static readonly TimeSpan MaximumCadence = new(0,30,0);
    private static readonly TimeSpan MinimumCadence = new(0,2,0);
    private const decimal MinimumDistance = 1M;

    public CalculateDurationFromCadenceCommandValidator()
    {
        RuleFor(c => c.cadence)
            .NotEmpty().WithMessage("Cadence is required.")
            .LessThan(MaximumCadence).WithMessage("Cadence must be faster than 02:00 min/km.")
            .GreaterThan(MinimumCadence).WithMessage("Cadence must be faster than 30:00 min/km.");
        RuleFor(c => c.distance)
            .NotEmpty().WithMessage("Distance is required.")
            .GreaterThanOrEqualTo(MinimumDistance).WithMessage("Distance must be greater than or equal to 1 km.");
    }
}