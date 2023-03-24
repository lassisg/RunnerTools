using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Commands.CreateActivity;
using RunnerTools.Application.Activities.Queries.GetActivities;

namespace WebUI.Pages.Activities;

// [Authorize]
public class Create : PageModel
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator) => _mediator = mediator;

    [BindProperty]
    public CreateActivityCommand Data { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        await _mediator.Send(Data);
        return RedirectToPage("Index");
    }
}