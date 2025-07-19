using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly OpenAIChatService _chatService;
    public string Response { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _chatService = new OpenAIChatService();
    }

    public async Task<IActionResult> OnPostAsync(string userMessage)
    {
        Response = await _chatService.GetChatResponse(userMessage);
        return Page();
    }

    public void OnGet()
    {

    }
}
