using FluentValidation;

namespace RunnerTools.Application.Activities.Commands.UpdateActivity;

public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityCommandValidator()
    {
        RuleFor(a => a.LocalTimeStamp)
            .NotEmpty().NotNull().WithMessage("Local timestamp is required.");
        RuleFor(a => a.SessionCount)
            .NotEmpty().NotNull().WithMessage("Session count is required.");
        RuleFor(a => a.Sessions)
            .NotEmpty().NotNull().WithMessage("There must be at least one session.");
    }
}