using MediatR;

namespace RunnerTools.Application.Simples.Commands.CalculateCadence;


public record CalculateCadenceFromSpeedCommand(decimal speed) : IRequest<MovementDto>;

public class CalculateCadenceFromSpeedCommandHandler : IRequestHandler<CalculateCadenceFromSpeedCommand, MovementDto>
{
    private const int MinutesInHour = 60;
    private const int SecondsInMinute = 60;

    public Task<MovementDto> Handle(CalculateCadenceFromSpeedCommand request, CancellationToken cancellationToken)
    {
        var cadenceInSeconds = MinutesInHour * SecondsInMinute / request.speed;
        var totalSeconds = (int)Decimal.Round(cadenceInSeconds);

        var entity = new MovementDto()
        {
            Cadence = new TimeSpan(0, 0, totalSeconds), 
            Speed = request.speed
        };

        return Task.FromResult(entity);
    }
}