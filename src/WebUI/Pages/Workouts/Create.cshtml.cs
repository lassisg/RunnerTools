using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Workouts.Commands.CreateWorkout;

namespace WebUI.Pages.Workouts;

// [Authorize]
public class Create : PageModel
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator) => _mediator = mediator;

    [BindProperty]
    public CreateWorkoutCommand Data { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        await _mediator.Send(Data);
        return RedirectToPage("Index");
    }
}