using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Commands.DeleteActivity;
using RunnerTools.Application.Activities.Queries.GetActivities;
using RunnerTools.Application.Workouts.Commands.DeleteWorkout;
using RunnerTools.Application.Workouts.Queries.GetWorkouts;

namespace WebUI.Pages.Workouts;

[Authorize]
public class Delete : PageModel
{
    private readonly IMediator _mediator;

    public Delete(IMediator mediator) => _mediator = mediator;

    [BindProperty]
    public WorkoutVm Data { get; set; }

    // public async Task OnGetAsync(GetWorkoutDetailQuery query) => 
    //     Data = await _mediator.Send(query); 

    public async Task OnGetAsync(GetWorkoutDetailQuery query)
    {
        Data = await _mediator.Send(query); 
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var deleteCommand = new DeleteWorkoutCommand(Data.Id);
        
        await _mediator.Send(deleteCommand);

        return RedirectToPage("Index");
    }
}