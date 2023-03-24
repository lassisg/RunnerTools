using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Queries.GetActivities;

namespace WebUI.Pages.Activities;

public class Index : PageModel
{
    private readonly IMediator _mediator;
    
    public Index(IMediator mediator) => _mediator = mediator;
    
    public ActivitiesVm Data { get; private set; }
    
    public async Task OnGetAsync() => Data = await _mediator.Send(new GetActivitiesQuery());
}