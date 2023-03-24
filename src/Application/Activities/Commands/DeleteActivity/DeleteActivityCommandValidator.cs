using FluentValidation;

namespace RunnerTools.Application.Activities.Commands.DeleteActivity;

public class DeleteActivityCommandValidator : AbstractValidator<DeleteActivityCommand>
{
    public DeleteActivityCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotNull().WithMessage("{PropertyName} is required!");
    }
}