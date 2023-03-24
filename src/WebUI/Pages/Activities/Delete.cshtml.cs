using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunnerTools.Application.Activities.Commands.DeleteActivity;
using RunnerTools.Application.Activities.Queries.GetActivities;

namespace WebUI.Pages.Activities;

[Authorize]
public class Delete : PageModel
{
    private readonly IMediator _mediator;

    public Delete(IMediator mediator) => _mediator = mediator;

    [BindProperty]
    public ActivityVm Data { get; set; }

    public async Task OnGetAsync(GetActivityDetailQuery query) => 
        Data = await _mediator.Send(query); 

    public async Task<IActionResult> OnPostAsync()
    {
        var deleteCommand = new DeleteActivityCommand(Data.Id);
        
        await _mediator.Send(deleteCommand);

        return RedirectToPage("Index");
    }
}