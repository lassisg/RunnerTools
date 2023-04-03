using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RunnerTools.Application.Basics.Commands.CalculateCadenceFromPlan;
using RunnerTools.Application.Basics.Commands.CalculateCadenceFromSpeed;
using RunnerTools.Application.Basics.Commands.CalculateSpeedFromCadence;
using RunnerTools.Application.Basics.Commands.CalculateSpeedFromPlan;
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
    
    [BindProperty]
    public RunningDurationDto CadencePlanData { get; set; }
    
    [BindProperty]
    public RunningDurationDto SpeedPlanData { get; set; }

    public async Task<IActionResult> OnGetAsync(GetRunningSpeedQuery speedQuery, 
                                                GetRunningCadenceQuery cadenceQuery,
                                                GetRunningDurationQuery durationQuery)
    {
        SpeedData = await _mediator.Send(speedQuery);
        CadenceData = await _mediator.Send(cadenceQuery);
        CadencePlanData = await _mediator.Send(durationQuery);
        SpeedPlanData = await _mediator.Send(durationQuery);
        
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
        var calculateCommand = new CalculateSpeedFromCadenceCommand(CadenceData.Cadence);
        
        CadenceData = await _mediator.Send(calculateCommand);
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostCadencePlanAsync()
    {
        var calculateCommand = new CalculateCadenceFromPlanCommand(CadencePlanData.Distance, CadencePlanData.Duration);
        
        CadencePlanData = await _mediator.Send(calculateCommand);
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostSpeedPlanAsync()
    {
        var calculateCommand = new CalculateSpeedFromPlanCommand(SpeedPlanData.Distance, SpeedPlanData.Duration);
        
        SpeedPlanData = await _mediator.Send(calculateCommand);
        
        return Page();
    }
    
}