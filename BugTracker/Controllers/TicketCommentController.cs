using BugTracker.Repositories;
using BugTracker.Repositories.Impl;
using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers;

[ApiController] [Route("api/tickets-comments")]
public class TicketCommentController : ControllerBase
{
    private readonly ITicketCommentsRepository _repository;

    public TicketCommentController(ITicketCommentsRepository ticketCommentsRepository)
    {
        _repository = ticketCommentsRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var ticketComments = _repository.GetAll().ToList();
        return Ok(ticketComments);
    }
}