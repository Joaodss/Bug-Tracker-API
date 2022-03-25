using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Services.Impl;

public class TicketCommentService : ITicketCommentService
{
    private readonly BugTrackerContext _context;

    public TicketCommentService(BugTrackerContext context)
    {
        _context = context;
    }


    public IEnumerable<TicketComment> GetAll()
    {
        return _context.Comments
            .ToList();
    }

    public IEnumerable<TicketComment> GetFromTicket(int ticketId)
    {
        return _context.Comments
            .Where(comment => comment.TicketId == ticketId)
            .ToList();
    }

    public IEnumerable<TicketComment> GetFromProject(int projectId)
    {
        return _context.Comments
            .Where(comment => comment.Ticket.ProjectId == projectId)
            .ToList();
    }

    public TicketComment GetById(int ticketId, int commentId)
    {
        return _context.Comments
            .FirstOrDefault(comment => comment.TicketId == ticketId && comment.Id == commentId);
    }

    public TicketComment GetById(int commentId)
    {
        return _context.Comments
            .FirstOrDefault(comment => comment.Id == commentId);
    }


    public void Create(int ticketId, TicketComment ticketComment)
    {
        ticketComment.TicketId = ticketId;
        _context.Comments.Add(ticketComment);
        _context.SaveChanges();
    }

    public void Update(int ticketId, int commentId, TicketComment ticketComment)
    {
        var comment = GetById(ticketId, commentId);
        if (comment is null)
        {
            return;
        }

        comment.content = ticketComment.content;
        _context.SaveChanges();
    }

    public void Delete(int ticketId, int commentId)
    {
        var comment = GetById(ticketId, commentId);
        if (comment is null)
        {
            return;
        }

        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }

    public void Delete(int commentId)
    {
        var comment = GetById(commentId);
        if (comment is null)
        {
            return;
        }

        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }
}