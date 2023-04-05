using MediatR;
using RunnerTools.Application.Common.Models;

namespace RunnerTools.Application.Basics.Commands.CalculateBasicData;

public record CalculateBasicDataCommand(RunningDto runningData) : IRequest<RunningDto>;

public class CalculateBasicDataCommandHandler : IRequestHandler<CalculateBasicDataCommand,RunningDto>
{
    public async Task<RunningDto> Handle(CalculateBasicDataCommand request, CancellationToken cancellationToken)
    {
        RunningCalculatorBase calculator;
        
        // DataStatus = "Calculate 'cadence' and 'speed' from 'distance' and 'duration'";
        if (RunningCalculatorBase.IsFullPlan(request.runningData))
            calculator = new RunningCalculatorFullPlan(request.runningData);

        // DataStatus = "Calculate 'duration' from 'cadence' or 'speed'";
        else if (RunningCalculatorBase.IsDuration(request.runningData))
            calculator = new RunningCalculatorDuration(request.runningData);

        // DataStatus = "Calculate 'speed' from 'cadence'";
        else if (RunningCalculatorBase.IsSpeed(request.runningData))
            calculator = new RunningCalculatorSpeedFromCadence(request.runningData);

        // DataStatus = "Calculate 'cadence' from 'speed'";
        else
            calculator = new RunningCalculatorCadenceFromSpeed(request.runningData);

        var result = calculator.Calculate();
        
        return result;
    }
}