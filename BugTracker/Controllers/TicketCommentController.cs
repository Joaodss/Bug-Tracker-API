using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers;

[ApiController] [Route("api/tickets-comments")]
public class TicketCommentController : ControllerBase
{
    private readonly ITicketCommentService _ticketCommentService;

    public TicketCommentController(ITicketCommentService ticketCommentService)
    {
        _ticketCommentService = ticketCommentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var ticketComments = _ticketCommentService.GetAll();
        return Ok(ticketComments);
    }
}