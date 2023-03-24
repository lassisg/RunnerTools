using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Queries.GetActivities;

namespace WebUI.Pages.Activities;

[Authorize]
public class Delete : PageModel
{
    private readonly IMediator _mediator;

    public Delete(IMediator mediator) => _mediator = mediator;

    [BindProperty]
    public ActivitiesVm Data { get; set; }

    public async Task OnGetAsync(GetActivitiesQuery query) => 
        Data = await _mediator.Send(query);

    public async Task<IActionResult> OnPostAsync()
    {
        await _mediator.Send(Data);

        return RedirectToPage("Index");
    }
}