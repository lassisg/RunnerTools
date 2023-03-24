using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Queries.GetActivities;
using RunnerTools.Application.Common.Models;
using RunnerTools.Application.Workouts.Queries.GetWorkouts;

namespace WebUI.Pages.Workouts;

public class Index : PageModel
{
    private readonly IMediator _mediator;
    
    public Index(IMediator mediator) => _mediator = mediator;
    
    public WorkoutsVm Data { get; private set; }
    
    public async Task OnGetAsync() => Data = await _mediator.Send(new GetWorkoutsQuery());   
}