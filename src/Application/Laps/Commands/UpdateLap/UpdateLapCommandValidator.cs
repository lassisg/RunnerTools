using FluentValidation;
using RunnerTools.Application.Laps.Commands.CreateLap;

namespace RunnerTools.Application.Laps.Commands.UpdateLap;

public class UpdateLapCommandValidator : AbstractValidator<UpdateLapCommand>
{
    public UpdateLapCommandValidator()
    {
        RuleFor(l=>l.StartTime)
            .NotEmpty().WithMessage("Start time is required.")
            .NotNull().WithMessage("Start time is required.");
        RuleFor(l=>l.TotalElapsedTime)
            .NotEmpty().WithMessage("Total elapsed time must not be empty.")
            .NotNull().WithMessage("Total elapsed time is required.");
        RuleFor(l=>l.TotalTimerTime)
            .NotEmpty().WithMessage("Total timer time must not be empty.")
            .NotNull().WithMessage("Total timer time is required.");
        RuleFor(l=>l.Timestamp)
            .NotEmpty().WithMessage("Timestamp must not be empty.")
            .NotNull().WithMessage("Timestamp is required.");
    }
}