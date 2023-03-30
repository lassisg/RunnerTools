using MediatR;
using RunnerTools.Application.Simples.Commands.CalculateCadence;

namespace RunnerTools.Application.Simples.Queries.GetBasics;

public record GetBasicCadenceQuery(decimal speed) : IRequest<MovementDto>;

public class GetBasicCalculationQueryHandler : IRequestHandler<GetBasicCadenceQuery, MovementDto>
{
    private const int MinutesInHour = 60;
    private const int SecondsInMinute = 60;

    public async Task<MovementDto> Handle(GetBasicCadenceQuery request, CancellationToken cancellationToken)
    {
        var totalSeconds = 0;
        var speed = 10M;
        if(request.speed > 0)
        {
            var cadenceInSeconds = MinutesInHour * SecondsInMinute / request.speed;
            totalSeconds = (int)Decimal.Round(cadenceInSeconds);
        }

        var entity = new MovementDto
        {
            Cadence = new TimeSpan(0, 0, totalSeconds), 
            Speed = speed
        };

        return entity;
    }
}