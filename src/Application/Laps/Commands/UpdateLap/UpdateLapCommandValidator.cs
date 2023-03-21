using FluentValidation;
using RunnerTools.Application.Laps.Commands.CreateLap;

namespace RunnerTools.Application.Laps.Commands.UpdateLap;

public class UpdateLapCommandValidator : AbstractValidator<UpdateLapCommand>
{
    public UpdateLapCommandValidator()
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