using FluentValidation;

namespace RunnerTools.Application.Basics.Commands.CalculateCadenceFromSpeed;

public class CalculateCadenceFromSpeedCommandValidator : AbstractValidator<CalculateCadenceFromSpeedCommand>
{
    // Based on the 50m World Record of 5.56 seconds
    private const decimal MaximumSpeed = 30M;
    private const decimal MinimumSpeed = 2M;
    
    public CalculateCadenceFromSpeedCommandValidator()
    {
        RuleFor(c => c.speed)
            .NotEmpty().WithMessage("Speed is required.")
            .LessThan(MaximumSpeed).WithMessage("Speed must be less than 30 km/h.")
            .GreaterThan(MinimumSpeed).WithMessage("Speed must be greater than 2 km/h.");
    }
}