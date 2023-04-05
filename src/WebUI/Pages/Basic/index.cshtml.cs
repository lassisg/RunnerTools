using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Basics.Commands.CalculateBasicData;
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

    [BindProperty] public RunningDto Data { get; set; }

    public async Task<IActionResult> OnGetAsync(GetRunningQuery query)
    {
        Data = await _mediator.Send(query);
        
        return Page();
    }

    // public async void OnPostAsync()
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Clear();
        
        var calculateCommand = new CalculateBasicDataCommand(Data);
        Data = await _mediator.Send(calculateCommand);

        return Page();
    }

}