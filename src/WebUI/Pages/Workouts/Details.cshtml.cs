using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Workouts.Queries.GetWorkouts;

namespace WebUI.Pages.Workouts;

public class Details : PageModel
{
    private readonly IMediator _mediator;

    public Details(IMediator mediator) => _mediator = mediator;

    public WorkoutVm Data { get; private set; }

    public async Task OnGetAsync(GetWorkoutDetailQuery query) => 
        Data = await _mediator.Send(query);
}