using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Queries.ExportActivities;
using RunnerTools.Application.Activities.Queries.GetActivities;

namespace WebUI.Pages.Activities;

public class Details : PageModel
{
    private readonly IMediator _mediator;

    public Details(IMediator mediator) => _mediator = mediator;

    public ActivityVm Data { get; private set; }

    public async Task OnGetAsync(GetActivityDetailQuery query) => 
        Data = await _mediator.Send(query);
}