using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Repositories.Impl;

public class TicketCommentsRepository : BaseRepository<TicketComment>, ITicketCommentsRepository
{
    public TicketCommentsRepository(ILogger<BaseRepository<TicketComment>> logger, BugTrackerContext context) :
        base(logger, context)
    {
    }
}