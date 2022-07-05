using DialogSearcher.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DialogSearcher.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MessengerController : ControllerBase
{
    private readonly IMessengerService _messengerService;

    public MessengerController(IMessengerService messengerService)
    {
        _messengerService = messengerService ?? throw new ArgumentNullException(nameof(messengerService));
    }
    
    /// <summary>
    /// Search clients dialog by client ids
    /// </summary>
    /// <param name="clientIds">Client ids</param>
    /// <returns>Clients dialog id</returns>
    [HttpPost("dialog/search")]
    public IActionResult SearchDialog(Guid[] clientIds) 
        => Ok(_messengerService.SearchDialogByClientIds(clientIds));
}