using BugTracker.Models;

namespace BugTracker.Services;

public interface ITicketCommentService
{
    IEnumerable<TicketComment> GetAll();
    IEnumerable<TicketComment> GetFromTicket(int ticketId);
    IEnumerable<TicketComment> GetFromProject(int projectId);
    TicketComment GetById(int ticketId, int commentId);
    TicketComment GetById(int commentId);
    void Create(int ticketId, TicketComment ticketComment);
    void Update(int ticketId, int commentId, TicketComment ticketComment);
    void Delete(int ticketId, int commentId);
    void Delete(int commentId);
}