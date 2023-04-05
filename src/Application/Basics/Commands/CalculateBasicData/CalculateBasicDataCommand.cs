using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Application.Services.RunningCalculator;

namespace RunnerTools.Application.Basics.Commands.CalculateBasicData;

public record CalculateBasicDataCommand(RunningData data) : IRequest<RunningData>;

public class CalculateBasicDataCommandHandler : IRequestHandler<CalculateBasicDataCommand, RunningData>
{
    public Task<RunningData> Handle(CalculateBasicDataCommand request, CancellationToken cancellationToken)
    {
        var calculator = RunningCalculatorFactory.GetRunningCalculator(request.data);
        var result = calculator.Calculate();
        
        return Task.FromResult(result);
    }
}