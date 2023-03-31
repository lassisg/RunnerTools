using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RunnerTools.Application.Basics.Commands.CalculateCadenceFromSpeed;
using RunnerTools.Application.Basics.Commands.CalculateSpeedFromCadence;
using RunnerTools.Application.Basics.Queries.GetBasics;
using RunnerTools.Application.Common.Models;

namespace WebUI.Pages.Basic;

public class index : PageModel
{
    private readonly IMediator _mediator;

    public index(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public RunningSpeedDto SpeedData { get; set; }
    
    [BindProperty]
    public RunningCadenceDto CadenceData { get; set; }

    public async Task<IActionResult> OnGetAsync(GetRunningSpeedQuery speedQuery, GetRunningCadenceQuery cadenceQuery)
    {
        SpeedData = await _mediator.Send(speedQuery);
        CadenceData = await _mediator.Send(cadenceQuery);
        return Page();
    }

    public async Task<IActionResult> OnPostSpeedAsync()
    {
        var calculateCommand = new CalculateCadenceFromSpeedCommand(SpeedData.Speed);
        
        SpeedData = await _mediator.Send(calculateCommand);
        return Page();
    }
    
    public async Task<IActionResult> OnPostCadenceAsync()
    {
        FixTimeInput();
        var calculateCommand = new CalculateSpeedFromCadenceCommand(CadenceData.Cadence);
        
        CadenceData = await _mediator.Send(calculateCommand);
        return Page();
    }

    public void FixTimeInput()
    {
        CadenceData.Cadence = new TimeSpan(0, CadenceData.Cadence.Hours, CadenceData.Cadence.Minutes);
    }
}