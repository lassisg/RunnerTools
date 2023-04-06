using AutoMapper;
using MediatR;
using RunnerTools.Application.Common.Models;
using RunnerTools.Application.Services.RunningCalculator;

namespace RunnerTools.Application.Basics.Commands.CalculateBasicData;

public record CalculateBasicDataCommand(RunningData data) : IRequest<RunningData>;

public class CalculateBasicDataCommandHandler : IRequestHandler<CalculateBasicDataCommand, RunningData>
{

    private readonly IMapper _mapper;

    public CalculateBasicDataCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<RunningData> Handle(CalculateBasicDataCommand request, CancellationToken cancellationToken)
    {
        var inputData = _mapper.Map<Running>(request.data);
        
        var calculator = RunningCalculatorFactory.GetRunningCalculator(inputData);
        
        // TODO: Map each calculator's input/output type
        var result = calculator.Calculate(inputData);
        
        var outputData = _mapper.Map<RunningData>(result);
        
        return Task.FromResult(outputData);
    }
}