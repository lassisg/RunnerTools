using FluentValidation;

namespace RunnerTools.Application.Records.Commands.UpdateRecord;

public class UpdateRecordCommandValidator : AbstractValidator<UpdateRecordCommand>
{
    public UpdateRecordCommandValidator()
    {
        RuleFor(r=>r.Timestamp)
            .NotEmpty().NotNull().WithMessage("Timestamp is required.");
    }
}