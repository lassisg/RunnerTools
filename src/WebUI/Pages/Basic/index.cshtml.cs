using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RunnerTools.Application.Simples.Commands.CalculateCadence;
using RunnerTools.Application.Simples.Queries.GetBasics;

namespace WebUI.Pages.Basic;

public class index : PageModel
{
    private readonly IMediator _mediator;

    public index(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public MovementDto Data { get; set; }
    public string Result { get; set; }

    public async void OnGetAsync(GetBasicCadenceQuery query)
    {
        Data = await _mediator.Send(query);
    }

    public async void OnPostAsync()
    {
        var calculateCommand = new CalculateCadenceFromSpeedCommand(Data.Speed);
        
        Data = await _mediator.Send(calculateCommand);
    }
    
}