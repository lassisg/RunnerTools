using FluentValidation;

namespace RunnerTools.Application.Activities.Commands.CreateActivity;

public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("{PropertyName} must not be empty.")
            .Length(3, 50).WithMessage("{PropertyName} must have between 3-50 characters.")
            .NotNull().WithMessage("{PropertyName} is required!");
        RuleFor(a => a.LocalTimeStamp)
            .NotEmpty().WithMessage("Local timestamp must not be empty.")
            .NotNull().WithMessage("Local timestamp is required.");
        RuleFor(a => a.SessionCount)
            .NotEmpty().WithMessage("Session count must not be empty.")
            .GreaterThan(0).WithMessage("Session count should be greater than 0.")
            .NotNull().WithMessage("Session count is required.");
    }
}