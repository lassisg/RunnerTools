using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages;

public class UserSecretModel : PageModel
{
    private readonly ILogger<UserSecretModel> _logger;

    public UserSecretModel(ILogger<UserSecretModel> logger)
    {
        _logger = logger;
    }
    public void OnGet()
    {
        
    }
}