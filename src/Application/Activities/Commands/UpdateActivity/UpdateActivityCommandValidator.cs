using FluentValidation;

namespace RunnerTools.Application.Activities.Commands.UpdateActivity;

public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityCommandValidator()
    {
        RuleFor(a => a.LocalTimeStamp)
            .NotEmpty().WithMessage("Local timestamp must not be empty.")
            .NotNull().WithMessage("Local timestamp is required.");
        RuleFor(a => a.SessionCount)
            .NotEmpty().WithMessage("Session count must not be empty.")
            .NotNull().WithMessage("Session count is required.");
        RuleFor(a => a.Sessions)
            .NotEmpty().WithMessage("There must not be empty.")
            .NotNull().WithMessage("At least one Session is required.");
    }
}