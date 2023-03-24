using FluentValidation;

namespace RunnerTools.Application.Sessions.Commands.CreateSession;

public class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
{
    public CreateSessionCommandValidator()
    {
        RuleFor(s=>s.StartTime)
            .NotEmpty().WithMessage("Start time must not be empty.")
            .NotNull().WithMessage("Start time is required.");
        RuleFor(s=>s.TotalElapsedTime)
            .NotEmpty().WithMessage("Total elapsed time must not be empty.")
            .NotNull().WithMessage("Total elapsed time is required.");
        RuleFor(s=>s.TotalTimerTime)
            .NotEmpty().WithMessage("Total timer time must not be empty.")
            .NotNull().WithMessage("Total timer time is required.");
        RuleFor(s=>s.Timestamp)
            .NotEmpty().WithMessage("Timestamp must not be empty.")
            .NotNull().WithMessage("Timestamp is required.");
    }
}