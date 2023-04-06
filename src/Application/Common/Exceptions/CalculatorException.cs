using FluentValidation.Results;

namespace RunnerTools.Application.Common.Exceptions;

public class CalculatorException : Exception
{
    public CalculatorException()
        : base("No calculator was found for given input.")
    { }
}
