using FluentValidation;

namespace RunnerTools.Application.Records.Commands.CreateRecord;

public class CreateRecordCommandValidator : AbstractValidator<CreateRecordCommand>
{
    public CreateRecordCommandValidator()
    {
        RuleFor(r=>r.Timestamp)
            .NotEmpty().NotNull().WithMessage("Timestamp is required.");
    }
}