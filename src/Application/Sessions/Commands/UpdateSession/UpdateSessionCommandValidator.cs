using FluentValidation;

namespace RunnerTools.Application.Sessions.Commands.UpdateSession;

public class UpdateSessionCommandValidator : AbstractValidator<UpdateSessionCommand>
{
    public UpdateSessionCommandValidator()
    {
        RuleFor(s=>s.StartTime)
            .NotEmpty().NotNull().WithMessage("Start time is required.");
        RuleFor(s=>s.TotalElapsedTime)
            .NotEmpty().NotNull().WithMessage("Total elapsed time is required.");
        RuleFor(s=>s.TotalTimerTime)
            .NotEmpty().NotNull().WithMessage("Total timer time is required.");
        RuleFor(s=>s.Timestamp)
            .NotEmpty().NotNull().WithMessage("Timestamp is required.");
    }
}