using FluentValidation;

namespace RunnerTools.Application.Laps.Commands.CreateLap;

public class CreateLapCommandValidator : AbstractValidator<CreateLapCommand>
{
    public CreateLapCommandValidator()
    {
        RuleFor(l=>l.StartTime)
            .NotEmpty().NotNull().WithMessage("Start time is required.");
        RuleFor(l=>l.TotalElapsedTime)
            .NotEmpty().NotNull().WithMessage("Total elapsed time is required.");
        RuleFor(l=>l.TotalTimerTime)
            .NotEmpty().NotNull().WithMessage("Total timer time is required.");
        RuleFor(l=>l.Timestamp)
            .NotEmpty().NotNull().WithMessage("Timestamp is required.");
    }
}